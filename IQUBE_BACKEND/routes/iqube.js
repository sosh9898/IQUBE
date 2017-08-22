var io = require("socket.io").listen(999);
var mysql = require('mysql');
var pool = mysql.createPool({
  connectionLimit : 10,
  host : '54.202.7.238',
  port : '/var/run/mysqld/mysqld.sock',
  user : 'root',
  database : 'iqubefinal',
  password : 'ekdrms24',
});


io.sockets.on("connection", function(socket){
    console.log("A user connected");
    
    ///맵저장
    socket.on("sMsg", function(data, error){
      if(error){
        console.log(error);
      }else{
        io.sockets.emit("rMsg", data);

        console.log("1 : data receive");
        pool.getConnection(function (err, connection){
        if(err)
          return console.log(err);
          console.log(data.userid);
        console.log("2 : query excute");
        connection.query('insert into maps values(?,?,?,?,?,?,?,?,?,?,?)',
        [null,data.userid,data.map,data.min,data.mode,data.size,data.total_count,data.succes_count,data.mapscore,data.mapname,data.username],  function(error,info){
          if(error == null){
            console.log("3 : query complete");
          }else{
            console.log(error);
          }
            connection.release();
            console.log("4 : query out");
            
        });

      });
    }
    });



            /// 마이 맵
    socket.on("mymap", function(data, error){
      if(error){
        console.log(error);
      }else{
        console.log("IN");
        pool.getConnection(function (err,connection){
        connection.query('select mapscore,idx,username,mapname,min,mode,size,total_count,succes_count, succes_count/total_count as rating from maps where userid = ? order by rating ASC',[data], function(error, data) {
            if (error) {
                    console.log(error);
            }
            else{
                for(var i =0; i<data.length; i++){
                io.sockets.emit("res_mymap", data[i]);
              }
            }
            connection.release();
        });
      });
      }
    });
    
   
    
     ///로그인
    socket.on("login", function(data, error){
      if(error){
        console.log(error);
      }else{
        console.log(data);
        console.log("login : data receive");
        pool.getConnection(function (err, connection){
        if(err)
          return console.log(err);

        console.log("login : query excute");
        connection.query('insert into user (userid, userscore, username)  select * from (select ?,?,?) as tmp where not exists ( select userid from user where userid = ?)',
        [data.userid, data.userscore, data.username, data.userid],  function(error,info){
          if(error == null){
            console.log("login : query complete");
          }else{
            console.log(error);
          }
            connection.release();
            console.log("login : query out");
            
        });

      });
    }
    });
    
   ///커스텀 플레이 성공
       socket.on("succes", function(data, error){
         if(error){
           console.log(error);
         }else{
         console.log("test");
           pool.getConnection(function (err, connection){
           if(err)
             return console.log(err);
           connection.query('update maps set mapscore = if(mapscore-20<0,0,mapscore-20), succes_count=succes_count+1, total_count=total_count+1 where idx = ?',
           [data.idx],  function(error,info){
             if(error == null){
               console.log("mapscore ok");
             }else{
               console.log(error);
             }
             connection.release();
               console.log("query out");
               

           });

           });
              pool.getConnection(function (err, connection){
           if(err)
             return console.log(err);
              connection.query('update user set userscore=userscore+20 where userid = ?',
           [data.userid],  function(error,info){
             if(error == null){
               console.log("userscore ok");
             }else{
               console.log(error);
             }
               connection.release();
               console.log("query out");

      

         });
           });
           
                 pool.getConnection(function (err, connection){
           if(err)
             return console.log(err);
              connection.query('insert into clearmap (userid, mapid) select * from (select ?,?) as tmp where not exists (select userid from clearmap where userid = ? and mapid = ?)',
           [data.userid,data.idx,data.userid,data.idx],  function(error,info){
             if(error == null){
               console.log("clearmap insert ok");
             }else{
               console.log(error);
             }
               connection.release();
               console.log("query out");

         });
           });
           
           
       }
       });
    
      ///커스텀 플레이 실패
       socket.on("fail", function(data, error){
         if(error){
           console.log(error);
         }else{
           pool.getConnection(function (err, connection){
           if(err)
             return console.log(err);
           connection.query('update maps set mapscore =mapscore+20, total_count=total_count+1 where idx = ?',
           [data.idx],  function(error,info){
             if(error == null){
               console.log("mapscore ok");
             }else{
               console.log(error);
             }
               connection.release();
           });
         });
              pool.getConnection(function (err, connection){
           if(err)
             return console.log(err);
                 connection.query('update user set userscore = if(userscore-20<0,0,userscore-20) where userid = ?',
           [data.userid],  function(error,info){
             if(error == null){
               console.log("userscore ok");
             }else{
               console.log(error);
             }
               connection.release();
               console.log("query out");

          });
        });
        
             pool.getConnection(function (err, connection){
           if(err)
             return console.log(err);
                 connection.query('update user set userscore=userscore+5 where userid = ?',
           [data.producer_],  function(error,info){
             if(error == null){
               console.log("producer ok");
             }else{
               console.log(error);
             }
               connection.release();
               console.log("query out");

          });
        });
        
       }
       });
    
      /// 리스트 클릭 시 맵 불러오기
     socket.on("map", function(data, error){
      if(error){
        console.log(error);
      }else{
        console.log("IN2");
        pool.getConnection(function (err,connection){
        connection.query('select map from maps where idx = ?',data , function(error, row) {
            if (error) {
                    console.log(error);
            }
            else{
              console.log(row[0]);
              io.sockets.emit("mmMsg", row[0]);
            }
            connection.release();
        });
      });
      }
    });

    /// 리스트 불러오기
      socket.on("load", function(data, error){
        if(error){
          console.log(error);
        }else{
          console.log("IN");
          pool.getConnection(function (err,connection){
          connection.query('select maps.mapscore,maps.idx,maps.userid,maps.mapname,maps.username,maps.min,maps.mode,maps.size,maps.total_count,maps.succes_count, maps.succes_count/maps.total_count as rating, if(clearmap.userid = ?, 1, 0) as flag from maps left outer join clearmap on (maps.idx = clearmap.mapid&&clearmap.userid = ?) order by idx DESC;',[data,data], function(error, row) {
              if (error) {
                      console.log(error);
              }
              else{
                  for(var i =0; i<data.length; i++){
          
                  io.sockets.emit("res_load_normal", row[i]);
                }
              }
              connection.release();
          });
        });
        }
      });

    
        /// 리스트 불러오기 ( 성공률 ) 
    socket.on("load_rate", function(data, error){
      if(error){
        console.log(error);
      }else{
        console.log("IN");
        pool.getConnection(function (err,connection){
        connection.query('select maps.mapscore,maps.idx,maps.userid,maps.mapname,maps.username,maps.min,maps.mode,maps.size,maps.total_count,maps.succes_count, maps.succes_count/maps.total_count as rating, if(clearmap.userid = ?, 1, 0) as flag from maps left outer join clearmap on (maps.idx = clearmap.mapid&&clearmap.userid = ?) order by rating ASC',[data,data], function(error, data) {
            if (error) {
                    console.log(error);
            }
            else{
                for(var i =0; i<data.length; i++){
                io.sockets.emit("res_load_rate", data[i]);
              }
            }
            connection.release();
        });
      });
      }
    });
    
            /// 리스트 불러오기 ( 조회수 ) 
    socket.on("load_count", function(data, error){
      if(error){
        console.log(error);
      }else{
        pool.getConnection(function (err,connection){
        connection.query('select maps.mapscore,maps.idx,maps.userid,maps.mapname,maps.username,maps.min,maps.mode,maps.size,maps.total_count,maps.succes_count, maps.succes_count/maps.total_count as rating, if(clearmap.userid = ?, 1, 0) as flag from maps left outer join clearmap on (maps.idx = clearmap.mapid&&clearmap.userid = ?) order by total_count DESC',[data,data], function(error, data) {
            if (error) {
                    console.log(error);
            }
            else{
                for(var i =0; i<data.length; i++){
                io.sockets.emit("res_load_count", data[i]);
              }
            }
            connection.release();
        });
      });
      }
    });
  ///내 순위 확인
socket.on("myrank", function(data, error){
  if(error){
    console.log(error);
  }else{
    pool.getConnection(function (err,connection){
    connection.query('select userid, userscore , @curRank := @curRank + 1 AS rank from user p, (select @curRank := 0) r order by userscore desc' ,data, function(errsor, row) {
        if (error) {
                console.log(error);
        }
        else{
         for(var i =0; i<row.length; i++){
                io.sockets.emit("res_myrank", row[i]);
              }
        }
        connection.release();
    });
  });
  }
});

});

var io = require("socket.io").listen(999);
var mysql = require('mysql');
var connection = mysql.createConnection({
  host :'localhost',
  port : 3306,
  user : 'root',
  password :'1234',
  database :'test'
});

console.log("start?");

io.sockets.on("connection", function(socket){
    console.log("A user connected");

    socket.on("sMsg", function(data, error){
      if(error){
        console.log(error);
      }else{
        io.sockets.emit("rMsg", data);

        console.log("1 : data receive");


        console.log("2 : query excute");
        connection.query('insert into map values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)',
        [data.name,data.min,data.map[0],data.map[1],data.map[2],data.map[3],data.map[4],data.map[5],data.map[6],data.map[7],data.map[8],data.map[9],data.map[10],data.map[11],data.map[12],data.map[13],data.map[14],data.map[15],data.map[16],data.map[17],data.map[18],data.map[19],data.map[20],data.map[21],data.map[22],data.map[23],data.map[24],data.map[25],data.map[26],data.map[27],data.map[28],data.map[29],data.map[30],data.map[31],data.map[32],data.map[33],data.map[34],data.map[35],data.map[36],data.map[37],data.map[38],data.map[39],data.map[40],data.map[41],data.map[42],data.map[43],data.map[44],data.map[45],data.map[46],data.map[47],data.map[48],data.map[49],data.map[50],data.map[51],data.map[52],data.map[53],data.map[54],data.map[55],data.map[56],data.map[57],data.map[58],data.map[59],data.map[60],data.map[61],data.map[62],data.map[63],data.map[64],data.map[65],data.map[66],data.map[67],data.map[68],data.map[69],data.map[70],data.map[71],data.map[72],data.map[73],data.map[74],data.map[75],data.map[76],data.map[77],data.map[78],data.map[79],data.map[80],data.map[81],data.map[82],data.map[83],data.map[84],data.map[85],data.map[86],data.map[87],data.map[88],data.map[89],data.map[90],data.map[91],data.map[92],data.map[93],data.map[94],data.map[95]],
        function(error,info){
          if(error == null){
            console.log("3 : query complete");
          }else{
            console.log(error);
          }
            connection.end();
            console.log("4 : query out");
        });

      }
    });

  /*  socket.on("mMsg", function(data, error){
      if(error){
        console.log(error);
      }else{
        connection.query('select * from map' function(error, result) {
            if (error) {
                    console.log(error);
            }
            else{
              console.log(result);
            }
            connection.end();
        });

        io.sockets.emit("mMsg", data);



      }
    }); */
});

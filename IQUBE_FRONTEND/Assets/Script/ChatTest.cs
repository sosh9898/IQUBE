
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using LitJson;
using System.Linq;

public class ChatTest : MonoBehaviour
{

    //Dictionary<string, string> data = new Dictionary<string, string>();
    //JSONObject jdata;

    [SerializeField]

    public Data A = new Data();
    public Data B = new Data();
    public User user = new User();
    public Point point = new Point();
    public Score score = new Score();
    public List<mainList> arr;
    public List<Score> arr_score;
    public List<Data> arr_my;


    public class User
    {
        public string userid;
        public string username;
        public int userscore;
    }
    public class Point
    {
        public string userid;
        public int idx;
        public string producer_;
    }

    public class Score
    {
        public string userid;
        public int userscore;
        public int rank;
    }

    public class Data
    {
        public int idx;
        public string userid;
        public string username;
        public string mapname;
        public string map;
        public int min;
        public int mode;
        public int size;
        public int total_count;
        public int succes_count;
        public float rating;
        public int mapscore;
        

    }

    public class mainList
    {
        public int idx;
        public string userid;
        public string username;
        public string mapname;
        public int min;
        public int mode;
        public int size;
        public int total_count;
        public int succes_count;
        public float rating;
        public int mapscore;
        public int flag;

    }

    public ChatTest()
    {
       // Debug.Log("ok");
    }

    public ChatTest(int idx)
    {
        A.idx = idx;
    }

    public ChatTest(string mapname, int[] map, int min, int mode, int size)
    {
        if(size==0)
        {

            for (int i = 0; i < 96; i++)
            {
                if (i == 0)
                {
                    A.map = map[i].ToString();
                }
                else if (i == 95)
                {
                    A.map += "," + map[i].ToString()+",";
                }else
                    A.map += "," + map[i].ToString();
                }
        }
        else if (size == 1)
        {
            for (int i = 0; i < 216; i++)
            {
                if (i == 0)
                {
                    A.map = map[i].ToString();
                }
                else if (i == 215)
                {
                    A.map += "," + map[i].ToString() + ",";
                }
                else
                    A.map += "," + map[i].ToString();
            }
        }

        string username = "";
        string userid = "";
        if (PlayerPrefs.HasKey("user_name")) { username = PlayerPrefs.GetString("user_name"); }
        else
            username = Social.localUser.userName;

        if (PlayerPrefs.HasKey("userid")) { userid = PlayerPrefs.GetString("userid"); }
        else 
            userid = Social.localUser.id;
        Debug.Log(userid + "      " + username);
        A.userid = userid;
        A.username = username;
        A.mapname = mapname; 
        A.min = min;
        A.mode = mode;
        A.size = size;
        A.mapscore = 1000;
        A.total_count = 0;
        A.succes_count = 0;
        A.rating = 0;
        

    }

    public void Login()
    {
        string username = "";
        string userid = "";
        if (PlayerPrefs.HasKey("user_name")) { username = PlayerPrefs.GetString("user_name");}
        if (PlayerPrefs.HasKey("userid")) { userid = PlayerPrefs.GetString("userid"); }

        user.userid = userid;
        user.username = username;
        user.userscore = 1000;
        SocketManager.Socket.Emit("login", user);
    }

    public void SendChat()
    {
        Debug.Log(A);
        SocketManager.Socket.Emit("sMsg", A);

    }

    public string rcvMap()
    {
        Debug.Log("load");
        string temp_map ="";
        SocketManager.Socket.Emit("map", A.idx);
        SocketManager.Socket.On("mmMsg", (result) =>
        {
            temp_map = result.Json.args[0].ToString();
            Debug.Log(temp_map);
        });

        System.Threading.Thread.Sleep(1500);
        Debug.Log(temp_map);
        return temp_map;
    }

  

    public void Succes(int idx)
    {
       
        string userid = "";
        if (PlayerPrefs.HasKey("userid")) { userid = PlayerPrefs.GetString("userid"); }
        point.idx = idx;
        point.userid = userid;
        SocketManager.Socket.Emit("succes", point);
    }
    public void Fail(int idx, string producer_)
    {
        string userid = "";
        if (PlayerPrefs.HasKey("userid")) { userid = PlayerPrefs.GetString("userid"); }
        point.idx = idx;
        point.userid = userid;
        point.producer_ = producer_;
        SocketManager.Socket.Emit("fail", point);
    }

    public List<Score> myrank()
    {
       
        arr_score = new List<Score>();
        SocketManager.Socket.Emit("myrank", "");
        SocketManager.Socket.On("res_myrank", (result) =>
        {
           Score score = JsonUtility.FromJson<Score>(result.Json.args[0].ToString());
           arr_score.Add(score);
        });

        System.Threading.Thread.Sleep(500);
        Debug.Log("test1");
        return arr_score;
    }
    public List<mainList> revChat()
    {
        string userid = "";
        if (PlayerPrefs.HasKey("userid")) { userid = PlayerPrefs.GetString("userid"); }

        arr = new List<mainList>();
        SocketManager.Socket.Emit("load", userid);
        SocketManager.Socket.On("res_load_normal", (result) =>
        {
            mainList t2 = JsonUtility.FromJson<mainList>(result.Json.args[0].ToString());
            arr.Add(t2);
        });

        Debug.Log("ok5");
        System.Threading.Thread.Sleep(500);

        return arr;
    }// 그냥
    public List<Data> revChatmy()
    {
        string userid = "";
        if (PlayerPrefs.HasKey("userid")) { userid = PlayerPrefs.GetString("userid"); }

        arr_my = new List<Data>();
        SocketManager.Socket.Emit("mymap", userid);
        SocketManager.Socket.On("res_mymap", (result) =>
        {
            Data t2 = JsonUtility.FromJson<Data>(result.Json.args[0].ToString());
            arr_my.Add(t2);
        });

        Debug.Log("ok5");
        System.Threading.Thread.Sleep(500);

        return arr_my;
    }
   //mymap
  
    public List<mainList> revChat2()
    {
        string userid = "";
        if (PlayerPrefs.HasKey("userid")) { userid = PlayerPrefs.GetString("userid"); }

        arr = new List<mainList>();
        SocketManager.Socket.Emit("load_rate", userid);
        SocketManager.Socket.On("res_load_rate", (result) =>
        {
            mainList t2 = JsonUtility.FromJson<mainList>(result.Json.args[0].ToString());
            arr.Add(t2);
        });

        Debug.Log("ok5");
        System.Threading.Thread.Sleep(500);

        return arr;
    } // DIFIICULT
    public List<mainList> revChat3()
    {
        string userid = "";
        if (PlayerPrefs.HasKey("userid")) { userid = PlayerPrefs.GetString("userid"); }


        arr = new List<mainList>();
        SocketManager.Socket.Emit("load_count", userid);
        SocketManager.Socket.On("res_load_count", (result) =>
        {
            mainList t2 = JsonUtility.FromJson<mainList>(result.Json.args[0].ToString());
            arr.Add(t2);
        });

        Debug.Log("ok5");
        System.Threading.Thread.Sleep(500);

        return arr;
    } // count

    void Start()
    {
        SocketManager.Socket.On("rMsg", (data) =>
        {
            Debug.Log(data.Json.args[0]);
        });
    }


}

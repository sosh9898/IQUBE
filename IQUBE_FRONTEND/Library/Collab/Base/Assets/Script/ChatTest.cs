
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
    public List<Data> arr;

    string tmp_map;

    public class User
    {
        public string userid;
        public string username;
        public int userscore;
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
    public int mypoint()
    {
        int temp_score = 0;
        string userid = "";
        if (PlayerPrefs.HasKey("userid")) { userid = PlayerPrefs.GetString("userid"); }

        SocketManager.Socket.Emit("mypoint",userid );
        SocketManager.Socket.On("res_mypoint", (result) =>
        {
            temp_score = (int)result.Json.args[0];
        });

        return temp_score;
    }

    public User myrank()
    {
        int temp_rank = 0;
        string userid = "";
        if (PlayerPrefs.HasKey("userid")) { userid = PlayerPrefs.GetString("userid"); }

        user = new User();
        user.userid = userid;
        SocketManager.Socket.Emit("myrank", user);
        SocketManager.Socket.On("res_myrank", (result) =>
        {
            user = (User)result.Json.args[0];
        });

        return user;
    }

    public void Succes(int idx)
    {
        A.idx = idx;
        SocketManager.Socket.Emit("succes", A.idx);
    }
    public void Fail(int idx)
    {
        A.idx = idx;
        SocketManager.Socket.Emit("fail", A.idx);
    }
    public List<Data> revChatmy()
    {
        string userid = "";
        if (PlayerPrefs.HasKey("userid")) { userid = PlayerPrefs.GetString("userid"); }

        arr = new List<Data>();
        SocketManager.Socket.Emit("mymap", userid);
        SocketManager.Socket.On("res_mymap", (result) =>
        {
            Data t2 = JsonUtility.FromJson<Data>(result.Json.args[0].ToString());
            arr.Add(t2);
        });

        Debug.Log("ok5");
        System.Threading.Thread.Sleep(2000);

        return arr;
    }
   //mymap
    public List<Data> revChat()
    {
        arr = new List<Data>();
        SocketManager.Socket.Emit("load", "");
        SocketManager.Socket.On("res_load_normal", (result) =>
        {           
            Data t2 = JsonUtility.FromJson<Data>(result.Json.args[0].ToString());
            arr.Add(t2);
        });

        Debug.Log("ok5");
        System.Threading.Thread.Sleep(2000);

        return arr;
    }// 그냥
    public List<Data> revChat2()
    {
        arr = new List<Data>();
        SocketManager.Socket.Emit("load_rate", "");
        SocketManager.Socket.On("res_load_rate", (result) =>
        {
            Data t2 = JsonUtility.FromJson<Data>(result.Json.args[0].ToString());
            arr.Add(t2);
        });

        Debug.Log("ok5");
        System.Threading.Thread.Sleep(2000);

        return arr;
    } // DIFIICULT
    public List<Data> revChat3()
    {
        arr = new List<Data>();
        SocketManager.Socket.Emit("load_count", "");
        SocketManager.Socket.On("res_load_count", (result) =>
        {
            Data t2 = JsonUtility.FromJson<Data>(result.Json.args[0].ToString());
            arr.Add(t2);
        });

        Debug.Log("ok5");
        System.Threading.Thread.Sleep(2000);

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

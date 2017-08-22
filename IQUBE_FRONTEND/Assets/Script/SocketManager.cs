using UnityEngine;
using System.Collections;
using SocketIOClient;

public class SocketManager : MonoBehaviour
{
    string url = "http://54.202.7.238:999/";
    public static Client Socket { get; private set; }

    void Awake()
    {
        Socket = new Client(url);
        Socket.Opened += SocketOpened;
        Socket.Connect();
    }

    private void SocketOpened(object sender, System.EventArgs e)
    {
        Debug.Log("Socket Opened");
    }

    void OnDisable()
    {
        Socket.Close();
    }
}

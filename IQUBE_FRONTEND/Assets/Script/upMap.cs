using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class upMap : MonoBehaviour
{
    public Text chatText;
    public Text chatWindow;

    List<string> buffer = new List<string>();

    // Use this for initialization
    void Start()
    {
        SocketManager.Socket.On("rMsg", (data) =>
        {
            Debug.Log(data.Json.args[0]);
            buffer.Add(data.Json.args[0].ToString());
        });
    }

    void Update()
    {
        if (buffer.Count <= 0) return;

        foreach (var b in buffer)
        {
            chatWindow.text += b + "\n";
        }
        buffer.Clear();
    }

    public void SendChat()
    {
        SocketManager.Socket.Emit("sMsg", chatText.text);
        chatText.text = "";
    }
    public void ReChat()
    {
        SocketManager.Socket.On("mMsg", (jdata) =>
        {
            Debug.Log(jdata.Json.args[0]);
            buffer.Add(jdata.Json.args[0].ToString());
        });
    }
}

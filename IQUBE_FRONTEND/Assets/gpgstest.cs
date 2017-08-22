using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class gpgstest : MonoBehaviour {

    public Text user;
    public Text score;
    public Text rank;
    string users= "";
    string score_u = "Score : ";
    string ranks = "Rank : ";
    string userid = "";
    int sco = 0;
    int rankaf = 0;
    // Use this for initialization
    void Start () {


        if (Social.localUser.authenticated)
        {
            users = Social.localUser.userName;
        }
        user.GetComponent<Text>().text = users;
        System.Threading.Thread.Sleep(1500);

        if (PlayerPrefs.HasKey("userid")) { userid = PlayerPrefs.GetString("userid"); }


        List<ChatTest.Score> scorelist = new List<ChatTest.Score>();

        ChatTest a = new ChatTest();
        scorelist = a.myrank();
        Debug.Log("test2");
        for(int i = 0; i < scorelist.Count; i++)
        {
            Debug.Log("testtt    "+scorelist.Count);
            if(scorelist[i].userid == userid)
            {
                sco = scorelist[i].userscore;
                rankaf = scorelist[i].rank;
                Debug.Log("test3");
            }
        }
        Debug.Log("test4");


        score.GetComponent<Text>().text = score_u + sco.ToString();
        rank.GetComponent<Text>().text = ranks + rankaf.ToString();
    }

	// Update is called once per frame
	void Update () {
		
	}
}

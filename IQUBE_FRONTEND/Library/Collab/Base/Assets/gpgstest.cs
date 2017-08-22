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
    // Use this for initialization
    void Start () {

        if (Social.localUser.authenticated)
        {
            users = Social.localUser.userName;
        }
        user.GetComponent<Text>().text = users;

        ChatTest ckckck = new ChatTest();
        string sco =ckckck.mypoint();
        score.GetComponent<Text>().text = score_u + sco;


        ChatTest adad = new ChatTest();
        string rankaf = adad.myrank();
        rank.GetComponent<Text>().text = ranks + rankaf;
    }
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_for_Login : MonoBehaviour {

    int bools = 0;
    ChatTest login;
    // Use this for initialization
    void Start () {

       
    }
	
	// Update is called once per frame
	void Update () {

        
        if (Social.localUser.authenticated)
        {
            string usern = Social.localUser.userName;
            string userid = Social.localUser.id;

            PlayerPrefs.SetString("user_name", usern);
            PlayerPrefs.SetString("userid", userid);

            if (PlayerPrefs.HasKey("user_id_bool"))
            {
                bools = PlayerPrefs.GetInt("user_id_bool");
            }

            if (bools == 0)
            {
                login = new ChatTest();
                login.Login();
                PlayerPrefs.SetInt("user_id_bool", 1);
            }
        }
    }
}

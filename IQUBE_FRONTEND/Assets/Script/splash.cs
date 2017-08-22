using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class splash : MonoBehaviour {
    void Start()
    {
        // Authenticate and register a ProcessAuthentication callback
        // This call needs to be made before we can proceed to other calls in the Social API

        PlayGamesPlatform.Activate();
        LoginGPGS();
        PlayerPrefs.SetInt("user_id_bool", 0);

        SceneController k = new SceneController();
        k.ChangeScene_String("main");
    }

    void LoginGPGS()
    {
        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate(ProcessAuthentication);


        }
    }

        // This function gets called when Authenticate completes
        // Note that if the operation is successful, Social.localUser will contain data from the server. 
        void ProcessAuthentication(bool success)
    {
        if (success)
        {
            Debug.Log("Authenticated, checking achievements");

            // Request loaded achievements, and register a callback for processing them
            Social.LoadAchievements(ProcessLoadedAchievements);
        }
        else
            Debug.Log("Failed to authenticate");
    }

    // This function gets called when the LoadAchievement call completes
    void ProcessLoadedAchievements(IAchievement[] achievements)
    {
        if (achievements.Length == 0)
            Debug.Log("Error: no achievements found");
        else
            Debug.Log("Got " + achievements.Length + " achievements");

        // You can also call into the functions like this
        Social.ReportProgress("Achievement01", 100.0, result => {
            if (result)
                Debug.Log("Successfully reported achievement progress");
            else
                Debug.Log("Failed to report achievement");
        });
    }
}

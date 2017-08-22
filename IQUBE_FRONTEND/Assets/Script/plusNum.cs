using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plusNum : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void plusStageNum()
    {
        int n=0; 
        if (PlayerPrefs.HasKey("stageNum")) n = PlayerPrefs.GetInt("stageNum");
        n = n + 1;
        PlayerPrefs.SetInt("stageNum", n );
    }

}

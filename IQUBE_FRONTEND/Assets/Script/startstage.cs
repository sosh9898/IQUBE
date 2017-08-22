using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startstage : MonoBehaviour {

    private SceneController A;
    private int stagenum;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void stat_st()
    {
        A = new SceneController();
        if (PlayerPrefs.HasKey("stageNum")) stagenum = PlayerPrefs.GetInt("stageNum");
        A.ChangeScene_String("stage"+ stagenum.ToString());

    }
}

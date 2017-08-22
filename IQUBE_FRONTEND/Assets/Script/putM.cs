using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class putM : MonoBehaviour {
    private int num=0;
    
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void pugStagenum(int k){
        num = k;
        PlayerPrefs.SetInt("stageNum",num);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setClassic()
    {
        PlayerPrefs.SetInt("customMode", 0);
    }
    public void setEXtend()
    {
        PlayerPrefs.SetInt("customMode", 1);

    }
    public void setLarge()
    {

        PlayerPrefs.SetInt("customsize", 1);
    }
    public void setNormal()
    {
        PlayerPrefs.SetInt("customsize", 0);

    }
}

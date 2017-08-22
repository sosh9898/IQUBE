using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extendstat : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("status" , 0);
		PlayerPrefs.SetInt("cstatus" , 0);
		PlayerPrefs.SetInt("cstatus1" , 0);
		PlayerPrefs.SetInt("cstatus2" , 0);
		PlayerPrefs.SetInt("cstatus3" , 0);
		PlayerPrefs.SetInt("cstatus4" , 0);
		PlayerPrefs.SetInt("cstatus5" , 0);
		PlayerPrefs.SetInt("cstatus6" , 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

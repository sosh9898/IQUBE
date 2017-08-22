using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour {
	private int tstat=0;
	public GameObject tu;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll ();
		if (PlayerPrefs.HasKey ("tstat")) {
			tstat = PlayerPrefs.GetInt ("tstat");
		} else
			tu.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void cstat(){
		tstat = 1;
		PlayerPrefs.SetInt ("tstat", tstat);
	}
}

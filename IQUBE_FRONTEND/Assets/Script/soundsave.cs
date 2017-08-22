using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundsave : MonoBehaviour {
	private int s;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("soundstat")) {
			s = PlayerPrefs.GetInt ("soundstat");
			if (s == 1) {
				AudioListener.volume = 1;
			} else if (s == 2) {
				AudioListener.volume = 0;
			}
		}
		else
			AudioListener.volume = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

﻿using UnityEngine;
using System.Collections;

public class audio : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SoundPlay() {
		GetComponent<AudioSource> ().Play();
	}
}

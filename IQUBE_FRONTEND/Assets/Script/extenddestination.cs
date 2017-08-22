using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extenddestination : MonoBehaviour {
	private Transform afterSave;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		afterSave = GameObject.Find ("Canvas").transform.FindChild ("setName");
		afterSave.gameObject.SetActive (true);
        PlayerPrefs.SetInt("clear_o", 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectSize : MonoBehaviour {

    public GameObject clearUI;
    // Use this for initialization
    void Start ()
    {

    }
    public void pop() {

        clearUI.SetActive(true);
    }
   
    public void cancle()
    {

        clearUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

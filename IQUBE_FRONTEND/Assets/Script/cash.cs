using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cash : MonoBehaviour {
	public int money;
	public Text mtext;
	public GameObject w;
	public GameObject x;
	public GameObject y;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("cash")) {
			money = PlayerPrefs.GetInt ("cash");
		} else
			money = 0;
		mtext.text = "x "+money.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.HasKey ("cash")) {
			money = PlayerPrefs.GetInt ("cash");
		}
		mtext.text = "x "+money.ToString ();
	}

	public void mapmake1(){
		if (money >= 3) {
			money -= 3;
			PlayerPrefs.SetInt ("cash", money);
			mtext.text = "x "+money.ToString ();
			SceneController sc = new SceneController ();
			sc.ChangeScene_String ("custom_normal");
		} else if (money < 3) {
			w.SetActive (true);
		}
	}

	public void mapmake2(){
		if (money >= 5) {
			money -= 5;
			PlayerPrefs.SetInt ("cash", money);
			mtext.text = "x "+money.ToString ();
			SceneController sc = new SceneController ();
			sc.ChangeScene_String ("custom_large");
		} else if (money < 5) {
			x.SetActive (true);
		}
	}

	public void mapmake3(){
		if (money >= 5) {
			money -= 5;
			PlayerPrefs.SetInt ("cash", money);
			mtext.text = "x "+money.ToString ();
			SceneController sc = new SceneController ();
			sc.ChangeScene_String ("custom_extend_normal");
		} else if (money < 5) {
			x.SetActive (true);
		}
	}

	public void mapplay(){
		if (money >= 1) {
			money -= 1;
			PlayerPrefs.SetInt ("cash", money);
			mtext.text = "x "+money.ToString ();
			SceneController sc = new SceneController ();
			sc.ChangeScene_String ("custom_extend_normal");
		} else if (money < 1) {
			y.SetActive (true);
		}
	}


	public void mappclear(){
			money += 2;
		PlayerPrefs.SetInt ("cash", money);
	}

	public void cheat(){
		money += 1000;
		PlayerPrefs.SetInt ("cash", money);
	}
}

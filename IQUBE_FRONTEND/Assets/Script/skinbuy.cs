using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skinbuy : MonoBehaviour {
	public GameObject x;
	public cash c;
	public Text mtext;
	private int n;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void sbuy(){
		if (PlayerPrefs.HasKey ("cash")) {
			n = PlayerPrefs.GetInt ("cash");
		}
		int ran;
		ran = Random.Range (1, 101);
		if (n >= 20) {
			n -= 20;
			PlayerPrefs.SetInt ("cash", n);
			mtext.text = "x "+n.ToString ();
			if (ran == 1) {
				PlayerPrefs.SetInt ("skinbuy", 1);
				PlayerPrefs.SetInt ("skinstat1", 1);
				SceneController sc = new SceneController();
				sc.ChangeScene_String("skinbuy");
			} else if (ran >= 2 && ran <= 5) {
				PlayerPrefs.SetInt ("skinbuy", 2);
				PlayerPrefs.SetInt ("skinstat2", 1);
				SceneController sc = new SceneController();
				sc.ChangeScene_String("skinbuy");
			} else if (ran >= 6 && ran <= 9) {
				PlayerPrefs.SetInt ("skinbuy", 3);
				PlayerPrefs.SetInt ("skinstat3", 1);
				SceneController sc = new SceneController();
				sc.ChangeScene_String("skinbuy");
			} else if (ran >= 10 && ran <= 16) {
				PlayerPrefs.SetInt ("skinbuy", 4);
				PlayerPrefs.SetInt ("skinstat4", 1);
				SceneController sc = new SceneController();
				sc.ChangeScene_String("skinbuy");
			} else if (ran >= 17 && ran <= 23) {
				PlayerPrefs.SetInt ("skinbuy", 5);
				PlayerPrefs.SetInt ("skinstat5", 1);
				SceneController sc = new SceneController();
				sc.ChangeScene_String("skinbuy");
			} else if (ran >= 24 && ran <= 30) {
				PlayerPrefs.SetInt ("skinbuy", 6);
				PlayerPrefs.SetInt ("skinstat6", 1);
				SceneController sc = new SceneController();
				sc.ChangeScene_String("skinbuy");
			} else if (ran >= 31 && ran <= 44) {
				PlayerPrefs.SetInt ("skinbuy", 7);
				PlayerPrefs.SetInt ("skinstat7", 1);
				SceneController sc = new SceneController();
				sc.ChangeScene_String("skinbuy");
			} else if (ran >= 45 && ran <= 58) {
				PlayerPrefs.SetInt ("skinbuy", 8);
				PlayerPrefs.SetInt ("skinstat8", 1);
				SceneController sc = new SceneController();
				sc.ChangeScene_String("skinbuy");
			} else if (ran >= 59 && ran <= 72) {
				PlayerPrefs.SetInt ("skinbuy", 9);
				PlayerPrefs.SetInt ("skinstat9", 1);
				SceneController sc = new SceneController();
				sc.ChangeScene_String("skinbuy");
			} else if (ran >= 73 && ran <= 86) {
				PlayerPrefs.SetInt ("skinbuy", 10);
				PlayerPrefs.SetInt ("skinstat10", 1);
				SceneController sc = new SceneController();
				sc.ChangeScene_String("skinbuy");
			} else if (ran >= 87 && ran <= 100) {
				PlayerPrefs.SetInt ("skinbuy", 11);
				PlayerPrefs.SetInt ("skinstat11", 1);
				SceneController sc = new SceneController();
				sc.ChangeScene_String("skinbuy");
			}
		} else if(n<20){
			x.SetActive (true);
		}
	}
}

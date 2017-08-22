using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c6 : MonoBehaviour {

	public int cstat=0;
	public GameObject cbox;
	public GameObject wall;

	void OnCollisionEnter2D(Collision2D collision)
	{
		PlayerPrefs.SetInt("conllsion", 1);
		if (PlayerPrefs.HasKey ("cstatus6")) {
			cstat = PlayerPrefs.GetInt ("cstatus6");
			if (cstat == 0) {
				PlayerPrefs.SetInt ("cstatus6", 1);
				wall.SetActive (false);
			}
			else if (cstat == 1) {
				PlayerPrefs.SetInt ("cstatus6", 0);
				cbox.SetActive (false);
				wall.SetActive (false);
			}
		} else {
			PlayerPrefs.SetInt ("cstatus6", 1);
			wall.SetActive (false);
		}
	}
}

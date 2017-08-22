using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navy : MonoBehaviour {

	public int stat=0;

	void OnCollisionEnter2D(Collision2D collision)
	{
        PlayerPrefs.SetInt("conllsion", 1);
        if (PlayerPrefs.HasKey ("status")) {
			stat = PlayerPrefs.GetInt ("status");
		} else
			stat = 0;

		if (stat == 5) {
			gameObject.SetActive (false);
			PlayerPrefs.SetInt("status" , 6);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red : MonoBehaviour {

		public int stat=0;

		void OnCollisionEnter2D(Collision2D collision)
		{
            PlayerPrefs.SetInt("conllsion", 1);
            if (PlayerPrefs.HasKey ("status")) {
				stat = PlayerPrefs.GetInt ("status");
			} else
				stat = 0;

			if (stat == 0) {
				gameObject.SetActive (false);
				PlayerPrefs.SetInt("status" , 1);
			}
		}
	}

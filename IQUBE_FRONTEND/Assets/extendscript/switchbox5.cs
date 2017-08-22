using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchbox5 : MonoBehaviour {
	public Vector3 scale; 
	public GameObject sbox;
	private Transform ybox;
	void OnCollisionEnter2D(Collision2D collision)
	{
		int x=0, y=0;
		PlayerPrefs.SetInt("conllsion", 1);
		scale = sbox.transform.localScale; 
		scale.y = 2; 
		sbox.transform.localScale = scale;
		for (x = 0; x <= 11; x++) {
			for (y = 0; y <= 11; y++) {
				ybox = GameObject.Find ("cube").transform.FindChild (string.Format ("switch8_x{0}_y{1}", x, y));
				if (ybox != null) {
					Destroy ((ybox as Transform).gameObject, 0f);
				}
			}
		}
	}
}
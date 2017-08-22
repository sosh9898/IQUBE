using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchbox : MonoBehaviour {
	public Vector3 scale; 
	public GameObject sbox;
	public GameObject ybox;
	void OnCollisionEnter2D(Collision2D collision)
	{
		PlayerPrefs.SetInt("conllsion", 1);
		scale = sbox.transform.localScale; 
		scale.x = 1; 
		sbox.transform.localScale = scale;
		ybox.SetActive (false);
		}
}
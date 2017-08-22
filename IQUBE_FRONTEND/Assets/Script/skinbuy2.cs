using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinbuy2 : MonoBehaviour {
	private int skinbuy;
	public GameObject[] grade = new GameObject[5];
	public GameObject[] skinimage = new GameObject[12];
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("skinbuy")) {
			skinbuy= PlayerPrefs.GetInt ("skinbuy");
			if (skinbuy == 1) {
				skinimage [11].SetActive (true);
				grade [1].SetActive (true);
			}
			else if (skinbuy == 2) {
				skinimage [10].SetActive (true);
				grade [2].SetActive (true);
			}
			else if (skinbuy == 3) {
				skinimage [9].SetActive (true);
				grade [2].SetActive (true);
			}
			else if (skinbuy == 4) {
				skinimage [8].SetActive (true);
				grade [3].SetActive (true);
			}
			else if (skinbuy == 5) {
				skinimage [7].SetActive (true);
				grade [3].SetActive (true);
			}
			else if (skinbuy == 6) {
				skinimage [6].SetActive (true);
				grade [3].SetActive (true);
			}
			else if (skinbuy == 7) {
				skinimage [5].SetActive (true);
				grade [4].SetActive (true);
			}
			else if (skinbuy == 8) {
				skinimage [4].SetActive (true);
				grade [4].SetActive (true);
			}
			else if (skinbuy == 9) {
				skinimage [3].SetActive (true);
				grade [4].SetActive (true);
			}
			else if (skinbuy == 10) {
				skinimage [2].SetActive (true);
				grade [4].SetActive (true);
			}
			else if (skinbuy == 11) {
				skinimage [1].SetActive (true);
				grade [4].SetActive (true);
			}
		} else
			skinbuy = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

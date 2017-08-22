using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeball : MonoBehaviour {
	public GameObject[] check = new GameObject[13];
	public GameObject[] moolum = new GameObject[12];
	public GameObject[] skinimage = new GameObject[12];
	public Button[] skinonoff = new Button[12];
	public int chstat;
	private int[] skinstat = new int[12];
	void Start () {
		if (PlayerPrefs.HasKey ("checkstat")) {
			chstat = PlayerPrefs.GetInt ("checkstat");
			if (chstat == 1) {
				for (int i = 1; i <= 12; i++) {
					check [i].SetActive (false);
				}
				check [1].SetActive (true);
			}
			if (chstat == 2) {
				for (int i = 1; i <= 12; i++) {
					check [i].SetActive (false);
				}
				check [2].SetActive (true);
			}
			if (chstat == 3) {
				for (int i = 1; i <= 12; i++) {
					check [i].SetActive (false);
				}
				check [3].SetActive (true);
			}
			if (chstat == 4) {
				for (int i = 1; i <= 12; i++) {
					check [i].SetActive (false);
				}
				check [4].SetActive (true);
			}
			if (chstat == 5) {
				for (int i = 1; i <= 12; i++) {
					check [i].SetActive (false);
				}
				check [5].SetActive (true);
			}
			if (chstat == 6) {
				for (int i = 1; i <= 12; i++) {
					check [i].SetActive (false);
				}
				check [6].SetActive (true);
			}
			if (chstat == 7) {
				for (int i = 1; i <= 12; i++) {
					check [i].SetActive (false);
				}
				check [7].SetActive (true);
			}
			if (chstat == 8) {
				for (int i = 1; i <= 12; i++) {
					check [i].SetActive (false);
				}
				check [8].SetActive (true);
			}
			if (chstat == 9) {
				for (int i = 1; i <= 12; i++) {
					check [i].SetActive (false);
				}
				check [9].SetActive (true);
			}
			if (chstat == 10) {
				for (int i = 1; i <= 12; i++) {
					check [i].SetActive (false);
				}
				check [10].SetActive (true);
			}
			if (chstat == 11) {
				for (int i = 1; i <= 12; i++) {
					check [i].SetActive (false);
				}
				check [11].SetActive (true);
			}
			if (chstat == 12) {
				for (int i = 1; i <= 12; i++) {
					check [i].SetActive (false);
				}
				check [12].SetActive (true);
			}
		}
		else
			check [1].SetActive (true);
		if (PlayerPrefs.HasKey ("skinstat1")) {
			skinstat [11] = PlayerPrefs.GetInt ("skinstat1");
			if (skinstat [11] == 1) {
				moolum [11].SetActive (false);
				skinimage [11].SetActive (true);
				skinonoff [11].GetComponent<Button> ().interactable = true;
			}
		} else
			skinstat [11] = 0;
		if (PlayerPrefs.HasKey ("skinstat2")) {
			skinstat [10] = PlayerPrefs.GetInt ("skinstat2");
			if (skinstat [10] == 1) {
				moolum [10].SetActive (false);
				skinimage [10].SetActive (true);
				skinonoff [10].GetComponent<Button> ().interactable = true;
			}
		} else
			skinstat [10] = 0;
		if (PlayerPrefs.HasKey ("skinstat3")) {
			skinstat [9] = PlayerPrefs.GetInt ("skinstat3");
			if (skinstat [9] == 1) {
				moolum [9].SetActive (false);
				skinimage [9].SetActive (true);
				skinonoff [9].GetComponent<Button> ().interactable = true;
			}
		} else
			skinstat [9] = 0;
		if (PlayerPrefs.HasKey ("skinstat4")) {
			skinstat [8] = PlayerPrefs.GetInt ("skinstat4");
			if (skinstat [8] == 1) {
				moolum [8].SetActive (false);
				skinimage [8].SetActive (true);
				skinonoff [8].GetComponent<Button> ().interactable = true;
			}
		} else
			skinstat [8] = 0;
		if (PlayerPrefs.HasKey ("skinstat5")) {
			skinstat [7] = PlayerPrefs.GetInt ("skinstat5");
			if (skinstat [7] == 1) {
				moolum [7].SetActive (false);
				skinimage [7].SetActive (true);
				skinonoff [7].GetComponent<Button> ().interactable = true;
			}
		} else
			skinstat [7] = 0;
		if (PlayerPrefs.HasKey ("skinstat6")) {
			skinstat [6] = PlayerPrefs.GetInt ("skinstat6");
			if (skinstat [6] == 1) {
				moolum [6].SetActive (false);
				skinimage [6].SetActive (true);
				skinonoff [6].GetComponent<Button> ().interactable = true;
			}
		} else
			skinstat [6] = 0;
		if (PlayerPrefs.HasKey ("skinstat7")) {
			skinstat [5] = PlayerPrefs.GetInt ("skinstat7");
			if (skinstat [5] == 1) {
				moolum [5].SetActive (false);
				skinimage [5].SetActive (true);
				skinonoff [5].GetComponent<Button> ().interactable = true;
			}
		} else
			skinstat [5] = 0;
		if (PlayerPrefs.HasKey ("skinstat8")) {
			skinstat [4] = PlayerPrefs.GetInt ("skinstat8");
			if (skinstat [4] == 1) {
				moolum [4].SetActive (false);
				skinimage [4].SetActive (true);
				skinonoff [4].GetComponent<Button> ().interactable = true;
			}
		} else
			skinstat [4] = 0;
		if (PlayerPrefs.HasKey ("skinstat9")) {
			skinstat [3] = PlayerPrefs.GetInt ("skinstat9");
			if (skinstat [3] == 1) {
				moolum [3].SetActive (false);
				skinimage [3].SetActive (true);
				skinonoff [3].GetComponent<Button> ().interactable = true;
			}
		} else
			skinstat [3] = 0;
		if (PlayerPrefs.HasKey ("skinstat10")) {
			skinstat [2] = PlayerPrefs.GetInt ("skinstat10");
			if (skinstat [2] == 1) {
				moolum [2].SetActive (false);
				skinimage [2].SetActive (true);
				skinonoff [2].GetComponent<Button> ().interactable = true;
			}
		} else
			skinstat [2] = 0;
		if (PlayerPrefs.HasKey ("skinstat11")) {
			skinstat [1] = PlayerPrefs.GetInt ("skinstat11");
			if (skinstat [1] == 1) {
				moolum [1].SetActive (false);
				skinimage [1].SetActive (true);
				skinonoff [1].GetComponent<Button> ().interactable = true;
			}
		} else
			skinstat [1] = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	public void cball1(){
		PlayerPrefs.SetInt ("bstat", 1);
		PlayerPrefs.SetInt ("checkstat", 1);
		for (int i = 1; i <= 12; i++) {
			check [i].SetActive (false);
		}
		check [1].SetActive (true);
	}
	public void cball2(){
		PlayerPrefs.SetInt ("bstat", 2);
		PlayerPrefs.SetInt ("checkstat", 2);
		for (int i = 1; i <= 12; i++) {
			check [i].SetActive (false);
		}
		check [2].SetActive (true);
	}
	public void cball3(){
		PlayerPrefs.SetInt ("bstat", 3);
		PlayerPrefs.SetInt ("checkstat", 3);
		for (int i = 1; i <= 12; i++) {
			check [i].SetActive (false);
		}
		check [3].SetActive (true);
	}
	public void cball4(){
		PlayerPrefs.SetInt ("bstat", 4);
		PlayerPrefs.SetInt ("checkstat", 4);
		for (int i = 1; i <= 12; i++) {
			check [i].SetActive (false);
		}
		check [4].SetActive (true);
	}
	public void cball5(){
		PlayerPrefs.SetInt ("bstat", 5);
		PlayerPrefs.SetInt ("checkstat", 5);
		for (int i = 1; i <= 12; i++) {
			check [i].SetActive (false);
		}
		check [5].SetActive (true);
	}
	public void cball6(){
		PlayerPrefs.SetInt ("bstat", 6);
		PlayerPrefs.SetInt ("checkstat", 6);
		for (int i = 1; i <= 12; i++) {
			check [i].SetActive (false);
		}
		check [6].SetActive (true);
	}
	public void cball7(){
		PlayerPrefs.SetInt ("bstat", 7);
		PlayerPrefs.SetInt ("checkstat", 7);
		for (int i = 1; i <= 12; i++) {
			check [i].SetActive (false);
		}
		check [7].SetActive (true);
	}
	public void cball8(){
		PlayerPrefs.SetInt ("bstat", 8);
		PlayerPrefs.SetInt ("checkstat", 8);
		for (int i = 1; i <= 12; i++) {
			check [i].SetActive (false);
		}
		check [8].SetActive (true);
	}
	public void cball9(){
		PlayerPrefs.SetInt ("bstat", 9);
		PlayerPrefs.SetInt ("checkstat", 9);
		for (int i = 1; i <= 12; i++) {
			check [i].SetActive (false);
		}
		check [9].SetActive (true);
	}
	public void cball10(){
		PlayerPrefs.SetInt ("bstat", 10);
		PlayerPrefs.SetInt ("checkstat", 10);
		for (int i = 1; i <= 12; i++) {
			check [i].SetActive (false);
		}
		check [10].SetActive (true);
	}
	public void cball11(){
		PlayerPrefs.SetInt ("bstat", 11);
		PlayerPrefs.SetInt ("checkstat", 11);
		for (int i = 1; i <= 12; i++) {
			check [i].SetActive (false);
		}
		check [11].SetActive (true);
	}
	public void cball12(){
		PlayerPrefs.SetInt ("bstat", 12);
		PlayerPrefs.SetInt ("checkstat", 12);
		for (int i = 1; i <= 12; i++) {
			check [i].SetActive (false);
		}
		check [12].SetActive (true);
	}
}

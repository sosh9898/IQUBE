using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class soundonoff : MonoBehaviour {
	public Button bon;
	public Button boff;
	private int sstat;
	void Start () {
		if (PlayerPrefs.HasKey ("soundstat")) {
			sstat = PlayerPrefs.GetInt ("soundstat");
			if (sstat == 1) {
				bon.GetComponent<Button> ().interactable = false;
				boff.GetComponent<Button> ().interactable = true;
			}
			if (sstat == 2) {
				boff.GetComponent<Button> ().interactable = false;
				bon.GetComponent<Button> ().interactable = true;
			}
		} else {
			boff.GetComponent<Button> ().interactable = true;
			bon.GetComponent<Button> ().interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void son(){
		AudioListener.volume = 1;
		bon.GetComponent<Button> ().interactable = false;
		boff.GetComponent<Button> ().interactable = true;
		PlayerPrefs.SetInt ("soundstat", 1);
	}
	public void soff(){
		AudioListener.volume = 0;
		boff.GetComponent<Button> ().interactable = false;
		bon.GetComponent<Button> ().interactable = true;
		PlayerPrefs.SetInt ("soundstat", 2);
	}
}

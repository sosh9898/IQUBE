using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class achievement : MonoBehaviour {
	public Button[] ac = new Button[6];
	public GameObject[] check = new GameObject[6];
	private int star;
	private int stat1;
	private int stat2;
	private int stat3;
	private int stat4;
	private int stat5;
	public cash m;
	public Text mtext;
	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey ("starsum")) {
			star=PlayerPrefs.GetInt("starsum");
		}
		else 
			star=0;

		if (PlayerPrefs.HasKey("achicheck1"))
		{
			check [1].SetActive (true);
		}
		else
			check [1].SetActive (false);
		if (PlayerPrefs.HasKey("achicheck2"))
		{
			check [2].SetActive (true);
		}
		else
			check [2].SetActive (false);
		if (PlayerPrefs.HasKey("achicheck3"))
		{
			check [3].SetActive (true);
		}
			else
				check [3].SetActive (false);
		if (PlayerPrefs.HasKey("achicheck4"))
		{
			check [4].SetActive (true);
		}
				else
					check [4].SetActive (false);
		if (PlayerPrefs.HasKey("achicheck5"))
		{
			check [5].SetActive (true);
		}
					else
						check [5].SetActive (false);

		if (PlayerPrefs.HasKey("stat1"))
		{
			stat1 = PlayerPrefs.GetInt("stat1");
		}
		else
			stat1 = 0;
		if (PlayerPrefs.HasKey("stat2"))
		{
			stat2 = PlayerPrefs.GetInt("stat2");
		}
		else
			stat2 = 0;
		if (PlayerPrefs.HasKey("stat3"))
		{
			stat3 = PlayerPrefs.GetInt("stat3");
		}
		else
			stat3 = 0;
		if (PlayerPrefs.HasKey("stat4"))
		{
			stat4 = PlayerPrefs.GetInt("stat4");
		}
		else
			stat4 = 0;
		if (PlayerPrefs.HasKey("stat5"))
		{
			stat5 = PlayerPrefs.GetInt("stat5");
		}
		else
			stat5 = 0;
		
        if (star >= 10 && stat1 == 0)
        {
            ac[1].GetComponent<Button>().interactable = true;
        }
		else
			ac[1].GetComponent<Button>().interactable = false;
        if (star >= 30 && stat2 == 0)
        {
            ac[2].GetComponent<Button>().interactable = true;
        }
		else
			ac[2].GetComponent<Button>().interactable = false;
        if (star >= 50 && stat3 == 0)
        {
            ac[3].GetComponent<Button>().interactable = true;
        }
		else
			ac[3].GetComponent<Button>().interactable = false;
        if (star >= 70 && stat4 == 0)
        {
            ac[4].GetComponent<Button>().interactable = true;
        }
		else
			ac[4].GetComponent<Button>().interactable = false;
        if (star >= 90 && stat5 == 0)
        {
            ac[5].GetComponent<Button>().interactable = true;
        }
		else
			ac[5].GetComponent<Button>().interactable = false;
    }
	
	// Update is called once per frame

	public void ac1(){
		m.money += 1;
		PlayerPrefs.SetInt ("cash", m.money);
		mtext.text = "x "+m.money.ToString ();
		check [1].SetActive (true);
		PlayerPrefs.SetInt ("achicheck1", 1);
		ac [1].GetComponent<Button> ().interactable = false;
		stat1 = 1;
		PlayerPrefs.SetInt ("stat1", stat1);
	}
	public void ac2(){
		m.money += 3;
		PlayerPrefs.SetInt ("cash", m.money);
		mtext.text = "x "+m.money.ToString ();
		check [2].SetActive (true);
		PlayerPrefs.SetInt ("achicheck2", 1);
		ac [2].GetComponent<Button> ().interactable = false;
		stat2 = 1;
		PlayerPrefs.SetInt ("stat2", stat2);
	}
	public void ac3(){
		m.money += 5;
		PlayerPrefs.SetInt ("cash", m.money);
		mtext.text = "x "+m.money.ToString ();
		check [3].SetActive (true);
		PlayerPrefs.SetInt ("achicheck3", 1);
		ac [3].GetComponent<Button> ().interactable = false;
		stat3 = 1;
		PlayerPrefs.SetInt ("stat3", stat3);
	}
	public void ac4(){
		m.money += 7;
		PlayerPrefs.SetInt ("cash", m.money);
		mtext.text = "x "+m.money.ToString ();
		check [4].SetActive (true);
		PlayerPrefs.SetInt ("achicheck4", 1);
		ac [4].GetComponent<Button> ().interactable = false;
		stat4 = 1;
		PlayerPrefs.SetInt ("stat4", stat4);
	}
	public void ac5(){
		m.money += 9;
		PlayerPrefs.SetInt ("cash", m.money);
		mtext.text = "x "+m.money.ToString ();
		check [5].SetActive (true);
		PlayerPrefs.SetInt ("achicheck5", 1);
		ac [5].GetComponent<Button> ().interactable = false;
		stat5 = 1;
		PlayerPrefs.SetInt ("stat5", stat5);
	}
}

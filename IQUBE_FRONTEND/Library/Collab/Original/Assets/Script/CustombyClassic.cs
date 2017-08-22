using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class CustombyClassic : MonoBehaviour
{
	public Button[] exbtn = new Button[23];
	private int modenum = 0;
	private Vector2 initMousePos;
	private Transform cubes;
	private int[] state = new int[96];
	private int setting = -1;
	private GameObject fiD;
	private GameObject Rainred, Rainorenge, Rainyellow, Raingreen, Rainblue, Rainnavy, Rainpupple;
	private GameObject obswitch1, obswitch2, obswitch3, obswitch4, obswitch5, obswitch6, obswitch7, obswitch8;
	private GameObject obdouble1, obdouble2, obdouble3, obdouble4, obdouble5, obdouble6;
	private Boolean fdo = true;  // final destination one bool
	private Boolean sred = true, sorenge = true, syellow = true, sgreen = true, sblue = true, snavy = true, spupple = true;
	private Boolean sswitch1 = true, sswitch2 = true, sswitch3 = true, sswitch4 = true, sswitch5 = true, sswitch6 = true, sswitch7 = true, sswitch8 = true;
	private Boolean sdouble1 = true, sdouble2 = true, sdouble3 = true, sdouble4 = true, sdouble5 = true, sdouble6 = true;
	private Transform afterSave;
	private Transform ImpossibleSave;
	public InputField nameFiled;
    private int count = 0;
    
	void Awake()
	{

	}
	public void setTrue()
	{
		setting = 1;
	}
	public void setFalse()
	{
		setting = 2;
	}
	public void setFinal()
	{
		setting = 3;
	}

	public void setred()
	{
		setting = 5;
		modenum = 1;
	}
	public void setorenge(){
		setting = 6;
		modenum = 1;
	}
	public void setyellow() {
		setting = 7;
		modenum = 1;
	}
	public void setgreen() {
		setting = 8;
		modenum = 1;
	}
	public void setblue() {
		setting = 9;
		modenum = 1;
	}
	public void setnavy() {
		setting = 10;
		modenum = 1;
	}
	public void setpupple() {
		setting = 11;
		modenum = 1;
	}

	public void setswitch1() {
		setting = 12;
		modenum = 1;
	}
	public void setswitch2(){
		setting = 13;
		modenum = 1;
	}
	public void setswitch3() {
		setting = 14;
		modenum = 1;
	}
	public void setswitch4() {
		setting = 15;
		modenum = 1;
	}
	public void setswitch5() {
		setting = 16;
		modenum = 1;
	}
	public void setswitch6() {
		setting = 17;
		modenum = 1;
	}
	public void setswitch7() {
		setting = 18;
		modenum = 1;
	}
	public void setswitch8() {
		setting = 19;
		modenum = 1;
	}

	public void setdouble1() {
		setting = 20;
		modenum = 1;
	}
	public void setdouble2() {
		setting = 21;
		modenum = 1;
	}
	public void setdouble3() {
		setting = 22;
		modenum = 1;
	}
	public void setdouble4() {
		setting = 23;
		modenum = 1;
	}
	public void setdouble5(){
		setting = 24;
		modenum = 1;
	}
	public void setdouble6()
	{
		setting = 25;
		modenum = 1;
	}

	public void backbtn()
	{
		afterSave = GameObject.Find("Canvas").transform.FindChild("setName");
		afterSave.gameObject.SetActive(false);
	}
	public void backbtn2()
	{
		afterSave = GameObject.Find("Canvas").transform.FindChild("notSave");
		afterSave.gameObject.SetActive(false);
	}
	public void nextbtn()
	{
        int custom_mode = 0;
        int map_size = 0;
        string userid = "";
        string username = "";
        if (PlayerPrefs.HasKey("customsize")) map_size = PlayerPrefs.GetInt("customsize");
        if (PlayerPrefs.HasKey("customMode")) custom_mode = PlayerPrefs.GetInt("customMode");
        String m_name = nameFiled.text;
        Debug.Log(m_name);
        if (PlayerPrefs.HasKey("userid"))
        {
            userid = PlayerPrefs.GetString("userid");
        }
        if (PlayerPrefs.HasKey("user_name"))
        {
            userid = PlayerPrefs.GetString("user_name");
        }
        ChatTest A = new ChatTest(userid, username, m_name, state, count, custom_mode, map_size);
        A.SendChat();
        SceneController sc = new SceneController();
        sc.ChangeScene_String("custommenu");
    }
	public void upMap()
	{
		setting = 4;
		cubeok ak = new cubeok(state,0,0);
		count = ak.start();
		if (modenum == 1) {
			afterSave = GameObject.Find ("Canvas").transform.FindChild ("possible");

            PlayerPrefs.SetInt("attach", 5);
        } else {
			if (count < 200) {
				afterSave = GameObject.Find ("Canvas").transform.FindChild ("setName");


			} else {
				afterSave = GameObject.Find ("Canvas").transform.FindChild ("notSave");

			}
		}
			afterSave.gameObject.SetActive (true);
	}

	public void OnMouseDown()
	{
		initMousePos = Input.mousePosition;
		initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);
		initMousePos.x += 4;
		initMousePos.y += 6;

		int x = (int)initMousePos.x;
		int y = (int)initMousePos.y;


		cubes = GameObject.Find("cube").transform.FindChild(string.Format("Tile_x{0}_y{1}", x, y));
		int n = x + y * 8;

		if (cubes != null)
		{
			if (setting == 2)
			{
				if (state[(x) + y * 8] == 1)
				{
					cubes.gameObject.SetActive(false);
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
				}
				else if (state[(x) + y * 8] == 2)
				{
					fdo = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("final_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 11)
				{
					sred = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("red_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 12)
				{
					sorenge = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("orenge_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 13)
				{
					syellow = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("yellow_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 14)
				{
					sgreen = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("green_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 15)
				{
					sblue = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("blue_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 16)
				{
					snavy = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("navy_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 17)
				{
					spupple = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("pupple_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 21)
				{
					sswitch1 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("switch1_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 22)
				{
					sswitch2 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("switch2_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 23)
				{
					sswitch3 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("switch3_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 24)
				{
					sswitch4 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("switch4_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 25)
				{
					sswitch5 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("switch5_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 26)
				{
					sswitch6 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("switch6_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 27)
				{
					sswitch7 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("switch7_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 28)
				{
					sswitch8 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("switch8_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}

				else if (state[(x) + y * 8] == 31)
				{
					sdouble1 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("double1_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 32)
				{
					sdouble2 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("double2_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 33)
				{
					sdouble3 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("double3_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 34)
				{
					sdouble4 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("double4_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 35)
				{
					sdouble5 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("double5_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}
				else if (state[(x) + y * 8] == 36)
				{
					sdouble6 = true;
					PlayerPrefs.SetInt("s" + n, 0);
					state[(x) + y * 8] = 0;
					cubes = GameObject.Find("cube").transform.FindChild(string.Format("double6_x{0}_y{1}", x, y));
					if (cubes != null)
					{
						Destroy((cubes as Transform).gameObject, 0f);
					}
				}

			}
			else if (setting == 1)
			{
				cubes.gameObject.SetActive(true);
				PlayerPrefs.SetInt("s" + n, 1);
				state[(x) + y * 8] = 1;
			}
			else if (setting == 3)
			{
				if (fdo)
				{
					fdo = false;
					fiD = GameObject.Find("FinalDestination");
					if (fiD != null)
					{
						fiD = GameObject.Instantiate(fiD, cubes.position, fiD.transform.rotation) as GameObject;
						fiD.name = string.Format("final_x{0}_y{1}", x, y);
						fiD.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 2;
					}
				}
			}
			/* rainbow 박스 생성 */
			else if (setting == 5)
			{
				if (sred)
				{
					sred = false;
					Rainred = GameObject.Find("red");
					if (Rainred != null)
					{
						Rainred = GameObject.Instantiate(Rainred, cubes.position, Rainred.transform.rotation) as GameObject;
						Rainred.name = string.Format("red_x{0}_y{1}", x, y);
						Rainred.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 11;
					}
				}
			}
			else if (setting == 6)
			{
				if (sorenge)
				{
					sorenge = false;
					Rainorenge = GameObject.Find("orenge");
					if (Rainorenge != null)
					{
						Rainorenge = GameObject.Instantiate(Rainorenge, cubes.position, Rainorenge.transform.rotation) as GameObject;
						Rainorenge.name = string.Format("orenge_x{0}_y{1}", x, y);
						Rainorenge.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 12;
					}
				}
			}
			else if (setting == 7)
			{
				if (syellow)
				{
					syellow = false;
					Rainyellow = GameObject.Find("yellow");
					if (Rainyellow != null)
					{
						Rainyellow = GameObject.Instantiate(Rainyellow, cubes.position, Rainyellow.transform.rotation) as GameObject;
						Rainyellow.name = string.Format("yellow_x{0}_y{1}", x, y);
						Rainyellow.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 13;
					}
				}
			}
			else if (setting == 8)
			{
				if (sgreen)
				{
					sgreen = false;
					Raingreen = GameObject.Find("green");
					if (Raingreen != null)
					{
						Raingreen = GameObject.Instantiate(Raingreen, cubes.position, Raingreen.transform.rotation) as GameObject;
						Raingreen.name = string.Format("green_x{0}_y{1}", x, y);
						Raingreen.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 14;
					}
				}
			}
			else if (setting == 9)
			{
				if (sblue)
				{
					sblue = false;
					Rainblue = GameObject.Find("blue");
					if (Rainblue != null)
					{
						Rainblue = GameObject.Instantiate(Rainblue, cubes.position, Rainblue.transform.rotation) as GameObject;
						Rainblue.name = string.Format("blue_x{0}_y{1}", x, y);
						Rainblue.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 15;
					}
				}
			}
			else if (setting == 10)
			{
				if (snavy)
				{
					snavy = false;
					Rainnavy = GameObject.Find("navy");
					if (Rainnavy != null)
					{
						Rainnavy = GameObject.Instantiate(Rainnavy, cubes.position, Rainnavy.transform.rotation) as GameObject;
						Rainnavy.name = string.Format("navy_x{0}_y{1}", x, y);
						Rainnavy.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 16;
					}
				}
			}
			else if (setting == 11)
			{
				if (spupple)
				{
					spupple = false;
					Rainpupple = GameObject.Find("pupple");
					if (Rainpupple != null)
					{
						Rainpupple = GameObject.Instantiate(Rainpupple, cubes.position, Rainpupple.transform.rotation) as GameObject;
						Rainpupple.name = string.Format("navy_x{0}_y{1}", x, y);
						Rainpupple.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 17;
					}
				}
			}
			/* 스위치 박스 생성 */
			else if (setting == 12)
			{
				if (sswitch1)
				{
					sswitch1 = false;
					obswitch1 = GameObject.Find("switch1");
					if (obswitch1 != null)
					{
						for (int i = 1; i <= 22; i++) {
							exbtn [i].GetComponent<Button> ().interactable = false;
						}
						exbtn[12].GetComponent<Button> ().interactable = true;
						obswitch1 = GameObject.Instantiate(obswitch1, cubes.position, obswitch1.transform.rotation) as GameObject;
						obswitch1.name = string.Format("switch1_x{0}_y{1}", x, y);
						obswitch1.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 21;
					}
				}
			}
			else if (setting == 13)
			{
				if (sswitch2)
				{
					sswitch2 = false;
					obswitch2 = GameObject.Find("switch2");
					if (obswitch2 != null)
					{
						for (int i = 1; i <= 22; i++) {
							exbtn [i].GetComponent<Button> ().interactable = false;
						}
						exbtn[13].GetComponent<Button> ().interactable = true;
						obswitch2 = GameObject.Instantiate(obswitch2, cubes.position, obswitch2.transform.rotation) as GameObject;
						obswitch2.name = string.Format("switch2_x{0}_y{1}", x, y);
						obswitch2.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 22;
					}
				}
			}
			else if (setting == 14)
			{
				if (sswitch3)
				{
					sswitch3 = false;
					obswitch3 = GameObject.Find("switch3");
					if (obswitch3 != null)
					{
						for (int i = 1; i <= 22; i++) {
							exbtn [i].GetComponent<Button> ().interactable = false;
						}
						exbtn[14].GetComponent<Button> ().interactable = true;
						obswitch3 = GameObject.Instantiate(obswitch3, cubes.position, obswitch3.transform.rotation) as GameObject;
						obswitch3.name = string.Format("switch3_x{0}_y{1}", x, y);
						obswitch3.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 23;
					}
				}
			}
			else if (setting == 15)
			{
				if (sswitch4)
				{
					sswitch4 = false;
					obswitch4 = GameObject.Find("switch4");
					if (obswitch4 != null)
					{
						for (int i = 1; i <= 22; i++) {
							exbtn [i].GetComponent<Button> ().interactable = false;
						}
						exbtn[15].GetComponent<Button> ().interactable = true;
						obswitch4 = GameObject.Instantiate(obswitch4, cubes.position, obswitch4.transform.rotation) as GameObject;
						obswitch4.name = string.Format("switch4_x{0}_y{1}", x, y);
						obswitch4.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 24;
					}
				}
			}
			else if (setting == 16)
			{
				if (sswitch5)
				{
					sswitch5 = false;
					obswitch5 = GameObject.Find("switch5");
					if (obswitch5 != null)
					{
						for (int i = 1; i <= 22; i++) {
							exbtn [i].GetComponent<Button> ().interactable = true;
						}
						exbtn[12].GetComponent<Button> ().interactable = false;
						exbtn[13].GetComponent<Button> ().interactable = false;
						exbtn[14].GetComponent<Button> ().interactable = false;
						exbtn[15].GetComponent<Button> ().interactable = false;
						obswitch5 = GameObject.Instantiate(obswitch5, cubes.position, obswitch5.transform.rotation) as GameObject;
						obswitch5.name = string.Format("switch5_x{0}_y{1}", x, y);
						obswitch5.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 25;
					}
				}
			}
			else if (setting == 17)
			{
				if (sswitch6)
				{
					sswitch6 = false;
					obswitch6 = GameObject.Find("switch6");
					if (obswitch6 != null)
					{
						for (int i = 1; i <= 22; i++) {
							exbtn [i].GetComponent<Button> ().interactable = true;
						}
						exbtn[12].GetComponent<Button> ().interactable = false;
						exbtn[13].GetComponent<Button> ().interactable = false;
						exbtn[14].GetComponent<Button> ().interactable = false;
						exbtn[15].GetComponent<Button> ().interactable = false;
						obswitch6 = GameObject.Instantiate(obswitch6, cubes.position, obswitch6.transform.rotation) as GameObject;
						obswitch6.name = string.Format("switch6_x{0}_y{1}", x, y);
						obswitch6.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 26;
					}
				}
			}
			else if (setting == 18)
			{
				if (sswitch7)
				{
					sswitch7 = false;
					obswitch7 = GameObject.Find("switch7");
					if (obswitch7 != null)
					{
						for (int i = 1; i <= 22; i++) {
							exbtn [i].GetComponent<Button> ().interactable = true;
						}
						exbtn[12].GetComponent<Button> ().interactable = false;
						exbtn[13].GetComponent<Button> ().interactable = false;
						exbtn[14].GetComponent<Button> ().interactable = false;
						exbtn[15].GetComponent<Button> ().interactable = false;
						obswitch7 = GameObject.Instantiate(obswitch7, cubes.position, obswitch7.transform.rotation) as GameObject;
						obswitch7.name = string.Format("switch7_x{0}_y{1}", x, y);
						obswitch7.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 27;
					}
				}
			}
			else if (setting == 19)
			{
				if (sswitch8)
				{
					sswitch8 = false;
					obswitch8 = GameObject.Find("switch8");
					if (obswitch8 != null)
					{
						for (int i = 1; i <= 22; i++) {
							exbtn [i].GetComponent<Button> ().interactable = true;
						}
						exbtn[12].GetComponent<Button> ().interactable = false;
						exbtn[13].GetComponent<Button> ().interactable = false;
						exbtn[14].GetComponent<Button> ().interactable = false;
						exbtn[15].GetComponent<Button> ().interactable = false;
						obswitch8 = GameObject.Instantiate(obswitch8, cubes.position, obswitch8.transform.rotation) as GameObject;
						obswitch8.name = string.Format("switch8_x{0}_y{1}", x, y);
						obswitch8.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 28;
					}
				}
			}
			/* double box 생성 */
			else if (setting == 20)
			{
				if (sdouble1)
				{
					    sdouble1 = false;
					    obdouble1 = GameObject.Find("double1");
					if (obdouble1 != null)
					{
						obdouble1 = GameObject.Instantiate(obdouble1, cubes.position, obdouble1.transform.rotation) as GameObject;
						obdouble1.name = string.Format("double1_x{0}_y{1}", x, y);
						obdouble1.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 31;
					}
				}
			}
			else if (setting == 21)
			{
				if (sdouble2)
				{
					sdouble2 = false;
					obdouble2 = GameObject.Find("double2");
					if (obdouble2 != null)
					{
						obdouble2 = GameObject.Instantiate(obdouble2, cubes.position, obdouble2.transform.rotation) as GameObject;
						obdouble2.name = string.Format("double2_x{0}_y{1}", x, y);
						obdouble2.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 32;
					}
				}
			}
			else if (setting == 22)
			{
				if (sdouble3)
				{
					sdouble3 = false;
					obdouble3 = GameObject.Find("double3");
					if (obdouble3 != null)
					{
						obdouble3 = GameObject.Instantiate(obdouble3, cubes.position, obdouble3.transform.rotation) as GameObject;
						obdouble3.name = string.Format("double3_x{0}_y{1}", x, y);
						obdouble3.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 33;
					}
				}
			}
			else if (setting == 23)
			{
				if (sdouble4)
				{
					sdouble4 = false;
					obdouble4 = GameObject.Find("double4");
					if (obdouble4 != null)
					{
						obdouble4 = GameObject.Instantiate(obdouble4, cubes.position, obdouble4.transform.rotation) as GameObject;
						obdouble4.name = string.Format("double4_x{0}_y{1}", x, y);
						obdouble4.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 34;
					}
				}
			}
			else if (setting == 24)
			{
				if (sdouble5)
				{
					sdouble5 = false;
					obdouble5 = GameObject.Find("double5");
					if (obdouble5 != null)
					{
						obdouble5 = GameObject.Instantiate(obdouble5, cubes.position, obdouble5.transform.rotation) as GameObject;
						obdouble5.name = string.Format("double3_x{0}_y{1}", x, y);
						obdouble5.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 35;
					}
				}
			}
			else if (setting == 25)
			{
				if (sdouble6)
				{
					sdouble6 = false;
					obdouble6 = GameObject.Find("double6");
					if (obdouble6 != null)
					{
						obdouble6 = GameObject.Instantiate(obdouble6, cubes.position, obdouble6.transform.rotation) as GameObject;
						obdouble6.name = string.Format("double6_x{0}_y{1}", x, y);
						obdouble6.transform.parent = cubes.transform.parent;
						PlayerPrefs.SetInt("s" + n, 2);
						state[(x) + y * 8] = 36;
					}
				}
			}


		}
	}
    void Start()
    {

        PlayerPrefs.SetInt("attach", 111);
    }
	void inits()
	{

		fdo = true;
		for (int n = 0; n <= 95; n++)
		{
			if (PlayerPrefs.HasKey("s" + n))
			{
				state[n] = PlayerPrefs.GetInt("s" + n);
				int x = n % 8;
				int y = n / 8;
				cubes = GameObject.Find("cube").transform.FindChild(string.Format("Tile_x{0}_y{1}", x, y));
				if (cubes != null)
				{
					if (state[n] == 1) cubes.gameObject.SetActive(true);
					else if (state[n] == 0) cubes.gameObject.SetActive(false);
					else if (state[n] == 2)
					{
						fdo = false;
						fiD = GameObject.Find("FinalDestination");
						fiD = GameObject.Instantiate(fiD, cubes.position, fiD.transform.rotation) as GameObject;
						fiD.transform.parent = cubes.transform.parent;
						Instantiate(fiD, cubes.position, fiD.transform.rotation);
						fiD.name = string.Format("Final_x{0}_y{1}", x, y);
					}
				}
			}
			else { state[n] = 0; }
		}
	}		
}

// Update is called once per frame


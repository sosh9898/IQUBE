using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class skinball__ : MonoBehaviour {
	public GameObject ballobj;
	public GameObject[] ballskin=new GameObject[13];
	private int ballstat=0;
	Rigidbody2D rigid;
	private bool attach = false;
	int move = 0;

	void Start () {
		if (PlayerPrefs.HasKey ("bstat")) {
			ballstat = PlayerPrefs.GetInt ("bstat");
		} else
			ballstat = 0;
		if (ballstat == 0 || ballstat == 1) {
			ballobj.GetComponent<SpriteRenderer> ().sprite = ballskin [1].GetComponent<SpriteRenderer> ().sprite;
			ballobj.GetComponent<Animator>().runtimeAnimatorController=GameObject.Find("ballskin").transform.FindChild("ballskin1").GetComponent<Animator>().runtimeAnimatorController;
		}
		if (ballstat == 2) {
			ballobj.GetComponent<SpriteRenderer> ().sprite = ballskin [2].GetComponent<SpriteRenderer> ().sprite;
			ballobj.GetComponent<Animator>().runtimeAnimatorController=GameObject.Find("ballskin").transform.FindChild("ballskin2").GetComponent<Animator>().runtimeAnimatorController;
		}
		if (ballstat == 3) {
			ballobj.GetComponent<SpriteRenderer> ().sprite = ballskin [3].GetComponent<SpriteRenderer> ().sprite;
			ballobj.GetComponent<Animator>().runtimeAnimatorController=GameObject.Find("ballskin").transform.FindChild("ballskin3").GetComponent<Animator>().runtimeAnimatorController;
		}
		if (ballstat == 4) {
			ballobj.GetComponent<SpriteRenderer> ().sprite = ballskin [4].GetComponent<SpriteRenderer> ().sprite;
			ballobj.GetComponent<Animator>().runtimeAnimatorController=GameObject.Find("ballskin").transform.FindChild("ballskin4").GetComponent<Animator>().runtimeAnimatorController;
		}
		if (ballstat == 5) {
			ballobj.GetComponent<SpriteRenderer> ().sprite = ballskin [5].GetComponent<SpriteRenderer> ().sprite;
			ballobj.GetComponent<Animator>().runtimeAnimatorController=GameObject.Find("ballskin").transform.FindChild("ballskin5").GetComponent<Animator>().runtimeAnimatorController;
		}
		if (ballstat == 6) {
			ballobj.GetComponent<SpriteRenderer> ().sprite = ballskin [6].GetComponent<SpriteRenderer> ().sprite;
			ballobj.GetComponent<Animator>().runtimeAnimatorController=GameObject.Find("ballskin").transform.FindChild("ballskin6").GetComponent<Animator>().runtimeAnimatorController;
		}
		if (ballstat == 7) {
			ballobj.GetComponent<SpriteRenderer> ().sprite = ballskin [7].GetComponent<SpriteRenderer> ().sprite;
			ballobj.GetComponent<Animator>().runtimeAnimatorController=GameObject.Find("ballskin").transform.FindChild("ballskin7").GetComponent<Animator>().runtimeAnimatorController;
		}
		if (ballstat == 8) {
			ballobj.GetComponent<SpriteRenderer> ().sprite = ballskin [8].GetComponent<SpriteRenderer> ().sprite;
			ballobj.GetComponent<Animator>().runtimeAnimatorController=GameObject.Find("ballskin").transform.FindChild("ballskin8").GetComponent<Animator>().runtimeAnimatorController;
		}
		if (ballstat == 9) {
			ballobj.GetComponent<SpriteRenderer> ().sprite = ballskin [9].GetComponent<SpriteRenderer> ().sprite;
			ballobj.GetComponent<Animator>().runtimeAnimatorController=GameObject.Find("ballskin").transform.FindChild("ballskin9").GetComponent<Animator>().runtimeAnimatorController;
		}
		if (ballstat == 10) {
			ballobj.GetComponent<SpriteRenderer> ().sprite = ballskin [10].GetComponent<SpriteRenderer> ().sprite;
			ballobj.GetComponent<Animator>().runtimeAnimatorController=GameObject.Find("ballskin").transform.FindChild("ballskin10").GetComponent<Animator>().runtimeAnimatorController;
		}
		if (ballstat == 11) {
			ballobj.GetComponent<SpriteRenderer> ().sprite = ballskin [11].GetComponent<SpriteRenderer> ().sprite;
			ballobj.GetComponent<Animator>().runtimeAnimatorController=GameObject.Find("ballskin").transform.FindChild("ballskin11").GetComponent<Animator>().runtimeAnimatorController;
		}
		if (ballstat == 12) {
			ballobj.GetComponent<SpriteRenderer> ().sprite = ballskin [12].GetComponent<SpriteRenderer> ().sprite;
			ballobj.GetComponent<Animator>().runtimeAnimatorController=GameObject.Find("ballskin").transform.FindChild("ballskin12").GetComponent<Animator>().runtimeAnimatorController;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{



		if (PlayerPrefs.HasKey("move_dire")) move = PlayerPrefs.GetInt("move_dire");


		if (move == 1)
			gameObject.transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f));
		else if (move == 2)
			gameObject.transform.Translate(new Vector3(0.1f, 0.0f, 0.0f));
		else if (move == 3)
			gameObject.transform.Translate(new Vector3(0.0f, -0.1f, 0.0f));
		else if (move == 4)
			gameObject.transform.Translate(new Vector3(0.0f, 0.1f, 0.0f));


		PlayerPrefs.SetInt("attach", 3);
	}
	// Update is called once per frame
	void Update()
	{
	}
}

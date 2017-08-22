using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class stageSetting : MonoBehaviour {

    static Transform stars_num;
    string starstring = "x0";
    public Button[] stagebtn = new Button[31];
    int n = 0;
    // Use this for initialization
    void Start () {
        //PlayerPrefs.DeleteAll ();
        stars_num = GameObject.Find("Canvas").transform.FindChild("stars_num");
        stars_num.GetComponent<Text>().text = starstring;
        if (PlayerPrefs.HasKey("num"))
        {
            n = PlayerPrefs.GetInt("num");
        }
        else
            n = 1;
        for(int i=1;i<=n;i++)
            stagebtn[i].GetComponent<Button> ().interactable =  true;
        int sum = 0;
        for (int i = 1; i < n; i++)
        {
            int b_star = 0;
            if (PlayerPrefs.HasKey("star" + i)) b_star = PlayerPrefs.GetInt("star" + i);
            sum += b_star;
        }
        if (n == 30)
        {
            int b_star = 0;
            if (PlayerPrefs.HasKey("star" + 30)) b_star = PlayerPrefs.GetInt("star" + 30);
            sum += b_star;
        }
        starstring = "x" + sum.ToString();
		PlayerPrefs.SetInt ("starsum", sum);
        stars_num.GetComponent<Text>().text = starstring;
    }

	
	// Update is called once per frame
	void Update () {
		
	}
    void awake()
    {

    }
}

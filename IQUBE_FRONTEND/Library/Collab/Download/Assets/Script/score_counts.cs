using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_counts : MonoBehaviour {

    int idx = -1;
    string producer_ = "";
    // Use this for initialization
    void Start () {

        if (PlayerPrefs.HasKey("cutomIdx")) idx = PlayerPrefs.GetInt("cutomIdx");
        if (PlayerPrefs.HasKey("producer_")) producer_ = PlayerPrefs.GetString("producer_");
    }
	public void clear_()
    {
        if (PlayerPrefs.HasKey("cutomIdx")) idx = PlayerPrefs.GetInt("cutomIdx");
        if (PlayerPrefs.HasKey("producer_")) producer_ = PlayerPrefs.GetString("producer_");
        Debug.Log("asdfasdf    " );
        //성공
        ChatTest temp = new ChatTest(idx);
        temp.Succes(idx);
    }

    public void fail_()
    {
        if (PlayerPrefs.HasKey("cutomIdx")) idx = PlayerPrefs.GetInt("cutomIdx");
        if (PlayerPrefs.HasKey("producer_")) producer_ = PlayerPrefs.GetString("producer_");
        //실패
        ChatTest temp = new ChatTest();
		temp.Fail(idx, producer_);

    }
	// Update is called once per frame
	void Update () {
		
	}
}

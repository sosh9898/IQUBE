using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear_cust : MonoBehaviour {

    public GameObject clearUI;
    public GameObject failUI;
    private int m_count = 0;
    private int map_min_count = 0;
    int kkkk = 0;
    // Use this for initialization
    void Start () {
        Debug.Log("test 2222222");
	}   
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
       
            PlayerPrefs.SetInt("clear_o", 1);
            PlayerPrefs.SetInt("conllsion", 1);

            if (PlayerPrefs.HasKey("m_count")) m_count = PlayerPrefs.GetInt("m_count");
            if (PlayerPrefs.HasKey("min_c")) map_min_count = PlayerPrefs.GetInt("min_c");


            if (m_count <= map_min_count)
            {
                clearUI.SetActive(true);
            }
            else
            {
                failUI.SetActive(true);
            }
           
    }
}
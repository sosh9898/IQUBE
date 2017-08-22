using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clear_my : MonoBehaviour
{
    
    private int m_count = 0;
    private int map_min_count = 0;
    public GameObject clear_;
    int kkkk = 0;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        PlayerPrefs.SetInt("clear_o", 1);
        PlayerPrefs.SetInt("conllsion", 1);
        clear_.SetActive(true);
    }
}
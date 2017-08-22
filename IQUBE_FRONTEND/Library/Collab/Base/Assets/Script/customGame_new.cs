using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class customGame_new : MonoBehaviour
{

    private Transform cubes;
    private string str_stage;
    private int[] stage;
    public Text toclear;
    private string tocle = "To clear : ";
    private GameObject fiD; // final instantiate Demo
    private int s_min=0 ; // 해당 맵의 최소 이동 횟수 stage minimum          
    private int m_count; // 움직인 횟수 moving count 
    // Use this for initialization
    ChatTest A;
    void Awake()
    {
    }

    void Start()
    {
        int idx = -1;
        int size = 0;
        if (PlayerPrefs.HasKey("cutomIdx")) idx = PlayerPrefs.GetInt("cutomIdx");
        if (PlayerPrefs.HasKey("cutomsize")) size = PlayerPrefs.GetInt("cutomsize");
        if (idx == -1) { }

        System.Threading.Thread.Sleep(300);

        A = new ChatTest(idx);
        str_stage =  A.rcvMap();



        if (PlayerPrefs.HasKey("min_c")) s_min = PlayerPrefs.GetInt("min_c");
        toclear.GetComponent<Text>().text = tocle + s_min.ToString();
        string[] stage_array = str_stage.Split(',');
        if (size == 0) {
            for (int n = 0; n <= 95; n++)
            {

                int a = n % 8;
                int b = n / 8;
                cubes = GameObject.Find("cube").transform.FindChild(string.Format("Tile_x{0}_y{1}", a, b));
                if (cubes != null)
                {
                    if (stage_array[n] == "1") cubes.gameObject.SetActive(true);
                    else if (stage_array[n] == "0") cubes.gameObject.SetActive(false);
                    else if (stage_array[n] == "2")
                    {
                        fiD = GameObject.Find("FinalDestination");
                        fiD = GameObject.Instantiate(fiD, cubes.position, fiD.transform.rotation) as GameObject;
                        fiD.transform.parent = cubes.transform.parent;
                        Instantiate(fiD, cubes.position, fiD.transform.rotation);
                        fiD.name = string.Format("Final_x{0}_y{1}", a, b);
                    }

                }
            }
        }
        else
        {
            for (int n = 0; n <= 215; n++)
            {

                int a = n % 12;
                int b = n / 12;
                cubes = GameObject.Find("cube").transform.FindChild(string.Format("Tile_x{0}_y{1}", a, b));
                if (cubes != null)
                {
                    if (stage_array[n] == "1") cubes.gameObject.SetActive(true);
                    else if (stage_array[n] == "0") cubes.gameObject.SetActive(false);
                    else if (stage_array[n] == "2")
                    {
                        fiD = GameObject.Find("FinalDestination");
                        fiD = GameObject.Instantiate(fiD, cubes.position, fiD.transform.rotation) as GameObject;
                        fiD.transform.parent = cubes.transform.parent;
                        Instantiate(fiD, cubes.position, fiD.transform.rotation);
                        fiD.name = string.Format("Final_x{0}_y{1}", a, b);
                    }

                }
            }
        }
        fiD = GameObject.Find("FinalDestination");
        if (fiD != null)
        {
            Destroy(fiD.gameObject,0f);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

}

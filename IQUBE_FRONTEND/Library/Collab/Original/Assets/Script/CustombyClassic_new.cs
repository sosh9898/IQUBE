using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class CustombyClassic_new : MonoBehaviour
{


    private Vector2 initMousePos;
    private Transform cubes;
    private int[] state=new int[216];
    private int size;
    public int row=18, col=12;
    private int setting = -1;
    private GameObject fiD;
    private Boolean fdo = true;  // final destination one bool
    private Transform afterSave;
    private Transform ImpossibleSave;
    public InputField nameFiled;
    private int count;

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
        if (PlayerPrefs.HasKey("customsize")) map_size = PlayerPrefs.GetInt("customsize");
        if (PlayerPrefs.HasKey("customMode")) custom_mode = PlayerPrefs.GetInt("customMode");
        String m_name = nameFiled.text;
        Debug.Log(m_name);
        ChatTest A = new ChatTest( m_name, state, count, custom_mode, map_size);
        A.SendChat();
        SceneController sc = new SceneController();
        sc.ChangeScene_String("custommenu");
    }
    public void upMap()
    {
        setting = 4;
        cubeok_new ak = new cubeok_new(row,col,state,0,0);
        count = ak.start();
        if (count < 200)
        {
            afterSave = GameObject.Find("Canvas").transform.FindChild("setName");
        }
        else
        {
            afterSave = GameObject.Find("Canvas").transform.FindChild("notSave");

        }
        afterSave.gameObject.SetActive(true);

    }

    public void OnMouseDown()
    {
        initMousePos = Input.mousePosition;
        initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);
       
        initMousePos.x += 4;
        initMousePos.x = initMousePos.x * 12 / 8;
        initMousePos.y += 6;
        initMousePos.y = initMousePos.y * 18 / 12;
        Debug.Log(initMousePos);
        int x = (int)initMousePos.x;
        int y = (int)initMousePos.y;


        cubes = GameObject.Find("cube").transform.FindChild(string.Format("Tile_x{0}_y{1}", x, y));
        int n = x + y * col;

        if (cubes != null)
        {
            if (setting == 2)
            {
                if (state[n] == 1)
                {
                    cubes.gameObject.SetActive(false);
                    PlayerPrefs.SetInt("s" + n, 0);
                    state[n] = 0;
                }
                else if (state[n] == 2)
                {
                    fdo = true;
                    PlayerPrefs.SetInt("s" + n, 0);
                    state[n] = 0;
                    cubes = GameObject.Find("cube").transform.FindChild(string.Format("final_x{0}_y{1}", x, y));
                    if (cubes != null)
                    {
                        Destroy((cubes as Transform).gameObject, 2f);
                    }
                }
            }
            else if (setting == 1)
            {
                cubes.gameObject.SetActive(true);
                PlayerPrefs.SetInt("s" + n, 1);
                state[n] = 1;
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
                        state[n] = 2;
                    }
                }
            }
        }
    }

    void inits()
    {
        size = row * col;
        fdo = true;
        for (int n = 0; n <= size; n++)
        {
            if (PlayerPrefs.HasKey("s" + n))
            {
                state[n] = PlayerPrefs.GetInt("s" + n);
                int x = n % col;
                int y = n / col;
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



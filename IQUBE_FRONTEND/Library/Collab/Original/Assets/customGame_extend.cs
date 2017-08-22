using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class customGame_extend : MonoBehaviour {

    private Transform cubes;
    private string str_stage;
    public Text toclear;
    private string tocle = "To clear : ";
    private GameObject fiD; // final instantiate Demo
    private GameObject Rainred, Rainorenge, Rainyellow, Raingreen, Rainblue, Rainnavy, Rainpupple;
    private GameObject obswitch1, obswitch2, obswitch3, obswitch4, obswitch5, obswitch6, obswitch7, obswitch8;
    private GameObject obdouble1, obdouble2, obdouble3, obdouble4, obdouble5, obdouble6;
    // extend object들
    ChatTest A;
    private int s_min; // 해당 맵의 최소 이동 횟수 stage minimum
                       //   private int m_count; // 움직인 횟수 moving count 
                       // Use this for initialization

    void Start()
    {

        s_min = 0;
        // 이부분도 받아와야하는뎅
        int idx = -1;
        if (PlayerPrefs.HasKey("cutomIdx")) idx = PlayerPrefs.GetInt("cutomIdx");
        if (idx == -1) { }
        System.Threading.Thread.Sleep(300);

        A = new ChatTest(idx);
        str_stage = A.rcvMap();


        if (PlayerPrefs.HasKey("min_c")) s_min = PlayerPrefs.GetInt("min_c");
        toclear.GetComponent<Text>().text = tocle + s_min.ToString();

        string[] stage = str_stage.Split(',');
        if (idx == -1) {

        }

        for (int n = 0; n <= 95; n++)
        {
            int x = n % 8;
            int y = n / 8;
            cubes = GameObject.Find("cube").transform.FindChild(string.Format("Tile_x{0}_y{1}", x, y));
            if (cubes != null)
            {
                if (stage[n] == "1") cubes.gameObject.SetActive(true);
                else if (stage[n] == "0") cubes.gameObject.SetActive(false);
                else if (stage[n] == "2")
                {
                    fiD = GameObject.Find("FinalDestination");
                    fiD = GameObject.Instantiate(fiD, cubes.position, fiD.transform.rotation) as GameObject;
                    fiD.transform.parent = cubes.transform.parent;
                    fiD.name = string.Format("Final_x{0}_y{1}", x, y);
                }else if (stage[n] == "11")
                {
                    Rainred = GameObject.Instantiate(Rainred, cubes.position, Rainred.transform.rotation) as GameObject;
                    Rainred.transform.parent = cubes.transform.parent;
                    Rainred.name = string.Format("red_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "12")
                {
                    Rainorenge = GameObject.Instantiate(Rainorenge, cubes.position, Rainorenge.transform.rotation) as GameObject;
                    Rainorenge.transform.parent = cubes.transform.parent;
                    Rainorenge.name = string.Format("orenge_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "13")
                {
                    Rainyellow = GameObject.Instantiate(Rainyellow, cubes.position, Rainyellow.transform.rotation) as GameObject;
                    Rainyellow.transform.parent = cubes.transform.parent;
                    Rainyellow.name = string.Format("yellow_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "14")
                {
                    Raingreen = GameObject.Instantiate(Raingreen, cubes.position, Raingreen.transform.rotation) as GameObject;
                    Raingreen.transform.parent = cubes.transform.parent;
                    Raingreen.name = string.Format("green_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "15")
                {
                    Rainblue = GameObject.Instantiate(Rainblue, cubes.position, Rainblue.transform.rotation) as GameObject;
                    Rainblue.transform.parent = cubes.transform.parent;
                    Rainblue.name = string.Format("blue_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "16")
                {
                    Rainnavy = GameObject.Instantiate(Rainnavy, cubes.position, Rainnavy.transform.rotation) as GameObject;
                    Rainnavy.transform.parent = cubes.transform.parent;
                    Rainnavy.name = string.Format("navy_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "17")
                {
                    Rainpupple = GameObject.Instantiate(Rainpupple, cubes.position, Rainpupple.transform.rotation) as GameObject;
                    Rainpupple.transform.parent = cubes.transform.parent;
                    Rainpupple.name = string.Format("pupple_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "21")
                {
                    obswitch1 = GameObject.Instantiate(obswitch1, cubes.position, obswitch1.transform.rotation) as GameObject;
                    obswitch1.transform.parent = cubes.transform.parent;
                    obswitch1.name = string.Format("switch1_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "22")
                {
                    obswitch2 = GameObject.Instantiate(obswitch2, cubes.position, obswitch2.transform.rotation) as GameObject;
                    obswitch2.transform.parent = cubes.transform.parent;
                    obswitch2.name = string.Format("switch2_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "23")
                {
                    obswitch3 = GameObject.Instantiate(obswitch3, cubes.position, obswitch3.transform.rotation) as GameObject;
                    obswitch3.transform.parent = cubes.transform.parent;
                    obswitch3.name = string.Format("switch3_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "24")
                {
                    obswitch4 = GameObject.Instantiate(obswitch4, cubes.position, obswitch4.transform.rotation) as GameObject;
                    obswitch4.transform.parent = cubes.transform.parent;
                    obswitch4.name = string.Format("switch4_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "25")
                {
                    obswitch5 = GameObject.Instantiate(obswitch5, cubes.position, obswitch5.transform.rotation) as GameObject;
                    obswitch5.transform.parent = cubes.transform.parent;
                    obswitch5.name = string.Format("switch5_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "26")
                {
                    obswitch6 = GameObject.Instantiate(obswitch6, cubes.position, obswitch6.transform.rotation) as GameObject;
                    obswitch6.transform.parent = cubes.transform.parent;
                    obswitch6.name = string.Format("switch6_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "27")
                {
                    obswitch7 = GameObject.Instantiate(obswitch7, cubes.position, obswitch7.transform.rotation) as GameObject;
                    obswitch7.transform.parent = cubes.transform.parent;
                    obswitch7.name = string.Format("switch7_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "28")
                {
                    obswitch8 = GameObject.Instantiate(obswitch8, cubes.position, obswitch8.transform.rotation) as GameObject;
                    obswitch8.transform.parent = cubes.transform.parent;
                    obswitch8.name = string.Format("switch8_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "31")
                {
                    obdouble1 = GameObject.Instantiate(obdouble1, cubes.position, obdouble1.transform.rotation) as GameObject;
                    obdouble1.transform.parent = cubes.transform.parent;
                    obdouble1.name = string.Format("double1_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "32")
                {
                    obdouble2 = GameObject.Instantiate(obdouble2, cubes.position, obdouble2.transform.rotation) as GameObject;
                    obdouble2.transform.parent = cubes.transform.parent;
                    obdouble2.name = string.Format("double2_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "33")
                {
                    obdouble3 = GameObject.Instantiate(obdouble3, cubes.position, obdouble3.transform.rotation) as GameObject;
                    obdouble3.transform.parent = cubes.transform.parent;
                    obdouble3.name = string.Format("double3_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "34")
                {
                    obdouble4 = GameObject.Instantiate(obdouble4, cubes.position, obdouble4.transform.rotation) as GameObject;
                    obdouble4.transform.parent = cubes.transform.parent;
                    obdouble4.name = string.Format("double4_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "35")
                {
                    obdouble5 = GameObject.Instantiate(obdouble5, cubes.position, obdouble5.transform.rotation) as GameObject;
                    obdouble5.transform.parent = cubes.transform.parent;
                    obdouble5.name = string.Format("double5_x{0}_y{1}", x, y);
                }
                else if (stage[n] == "36")
                {
                    obdouble6 = GameObject.Instantiate(obdouble6, cubes.position, obdouble6.transform.rotation) as GameObject;
                    obdouble6.transform.parent = cubes.transform.parent;
                    obdouble6.name = string.Format("double6_x{0}_y{1}", x, y);
                }

            }
        }
        fiD = GameObject.Find("FinalDestination");
        if (fiD != null)
        {
            Destroy(fiD.gameObject, 0f);
        }

        Rainred = GameObject.Find("red");
        if (Rainred != null)
        {

            Destroy(Rainred.gameObject, 0f);
        }
        Rainorenge = GameObject.Find("orenge");
        if (Rainorenge != null)
        {

            Destroy(Rainorenge.gameObject, 0f);
        }

        Rainyellow = GameObject.Find("yellow");
        if (Rainyellow != null)
        {

            Destroy(Rainyellow.gameObject, 0f);
        }
        Raingreen = GameObject.Find("green");
        if (Raingreen != null)
        {

            Destroy(Raingreen.gameObject, 0f);
        }
        Rainblue = GameObject.Find("blue");
        if (Rainblue != null)
        {

            Destroy(Rainblue.gameObject, 0f);
        }
        Rainnavy = GameObject.Find("navy");
        if (Rainnavy != null)
        {

            Destroy(Rainnavy.gameObject, 0f);
        }
        Rainpupple = GameObject.Find("pupple");
        if (Rainpupple != null)
        {

            Destroy(Rainpupple.gameObject, 0f);
        }
        obswitch1 = GameObject.Find("switch1");
        if (obswitch1 != null)
        {

            Destroy(obswitch1.gameObject, 0f);
        }
        obswitch2 = GameObject.Find("switch2");
        if (obswitch2 != null)
        {

            Destroy(obswitch2.gameObject, 0f);
        }
        obswitch3 = GameObject.Find("switch3");
        if (obswitch3 != null)
        {

            Destroy(obswitch3.gameObject, 0f);
        }
        obswitch4 = GameObject.Find("switch4");
        if (obswitch4 != null)
        {

            Destroy(obswitch4.gameObject, 0f);
        }
        obswitch5 = GameObject.Find("switch5");
        if (obswitch5 != null)
        {

            Destroy(obswitch5.gameObject, 0f);
        }
        obswitch6 = GameObject.Find("switch6");
        if (obswitch6 != null)
        {

            Destroy(obswitch6.gameObject, 0f);
        }
        obswitch7 = GameObject.Find("switch7");
        if (obswitch7 != null)
        {

            Destroy(obswitch7.gameObject, 0f);
        }
        obswitch8 = GameObject.Find("switch8");
        if (obswitch8 != null)
        {

            Destroy(obswitch8.gameObject, 0f);
        }
        obdouble1 = GameObject.Find("double1");
        if (obdouble1 != null)
        {

            Destroy(obdouble1.gameObject, 0f);
        }
        obdouble2 = GameObject.Find("double2");
        if (obdouble2 != null)
        {

            Destroy(obdouble2.gameObject, 0f);
        }
        obdouble3 = GameObject.Find("double3");
        if (obdouble3 != null)
        {

            Destroy(obdouble3.gameObject, 0f);
        }
        obdouble4 = GameObject.Find("double4");
        if (obdouble4 != null)
        {

            Destroy(obdouble4.gameObject, 0f);
        }
        obdouble5 = GameObject.Find("double5");
        if (obdouble5 != null)
        {

            Destroy(obdouble5.gameObject, 0f);
        }
        obdouble6 = GameObject.Find("double6");
        if (obdouble6 != null)
        {

            Destroy(obdouble6.gameObject, 0f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {
        Rainred = GameObject.Find("red");
        Rainorenge = GameObject.Find("orenge");
        Rainyellow = GameObject.Find("yellow");
        Raingreen = GameObject.Find("green");
        Rainblue = GameObject.Find("blue");
        Rainnavy = GameObject.Find("navy");
        Rainpupple = GameObject.Find("pupple");
        obswitch1 = GameObject.Find("switch1");
        obswitch2 = GameObject.Find("switch2");
        obswitch3 = GameObject.Find("switch3");
        obswitch4 = GameObject.Find("switch4");
        obswitch5 = GameObject.Find("switch5");
        obswitch6 = GameObject.Find("switch6");
        obswitch7 = GameObject.Find("switch7");
        obswitch8 = GameObject.Find("switch8");
        obdouble1 = GameObject.Find("double1");
        obdouble2 = GameObject.Find("double2");
        obdouble3 = GameObject.Find("double3");
        obdouble4 = GameObject.Find("double4");
        obdouble5 = GameObject.Find("double5");
        obdouble6 = GameObject.Find("double6");
        // 초기화
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class screenT : MonoBehaviour {

    Rigidbody2D rigid;
    static Transform text;
    public float power = 1f;
    private Vector2 Ke;
    private Vector2 currotation;
    private Vector2 worldPoint;
    private Vector2 initMousePos;
    
    private int attach ;

    private int m_count = 0;
    public Text myText;
    string movements = "movements : 0";
    public GameObject ball;
    private int clear_o=0;
    static public void set_Text(int k)
    {
        int n = k;
        string m = "movements : " + n.ToString();
        text.GetComponent<Text>().text = m;
    }

    void OnMouseDown()
    {
        if (PlayerPrefs.HasKey("clear_o")) clear_o = PlayerPrefs.GetInt("clear_o");
        if (clear_o == 0) { 
            if (attach == 5)
            {
                PlayerPrefs.SetInt("conllsion", 0);
                initMousePos = Input.mousePosition;
                initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);
                Debug.Log(initMousePos);
                PlayerPrefs.SetInt("attach", 2);
            }
        }

    }

    void OnMouseUp()
    {
        if (attach == 2)
        {

            PlayerPrefs.SetInt("attach", 1);


            worldPoint = Input.mousePosition;
            worldPoint = Camera.main.ScreenToWorldPoint(worldPoint);

            Ke = worldPoint - initMousePos;

            Debug.Log(worldPoint - initMousePos);


            if (Mathf.Abs(Ke.x) == 0 && Mathf.Abs(Ke.y) == 0)
            {
                PlayerPrefs.SetInt("attach", 2);
                attach = 2;
            }
            else
            {
                m_count++;
                PlayerPrefs.SetInt("m_count", m_count);

                currotation = ball.transform.position;
                set_Text(m_count); if (Mathf.Abs(Ke.x) > Mathf.Abs(Ke.y))
                {
                    if (Ke.x > 0)
                    {
                        PlayerPrefs.SetInt("move_dire", 1);
                        rigid.AddForce(Vector2.right * power);//오른쪽
                    }
                    else
                    {
                        PlayerPrefs.SetInt("move_dire", 2);
                        rigid.AddForce(Vector2.left * power);//왼쪽
                    }
                }
                else
                {
                    if (Ke.y > 0)
                    {
                        PlayerPrefs.SetInt("move_dire", 3);
                        rigid.AddForce(Vector2.up * power); //위쪽
                    }
                    else
                    {
                        PlayerPrefs.SetInt("move_dire", 4);
                        rigid.AddForce(Vector2.down * power);// 아래쪽
                    }


                }
            }

        }
    }

    void FixedUpdate()
    {

        if (PlayerPrefs.HasKey("attach")) attach = PlayerPrefs.GetInt("attach");

        if(attach == 3)
        {
            Vector2 afterPo;
            afterPo = ball.transform.position;
            int collsion = 0;
            if (PlayerPrefs.HasKey("conllsion")) collsion = PlayerPrefs.GetInt("conllsion");

            if (Mathf.Abs(afterPo.x - currotation.x) + Mathf.Abs(afterPo.y - currotation.y) < 0.3 && collsion != 1)
                m_count--;
            set_Text(m_count);

            PlayerPrefs.SetInt("attach", 5);
            attach = 5;
        }
    }

    // Use this for initialization
    void Awake()
    {

        PlayerPrefs.SetInt("clear_o", 0);
        PlayerPrefs.SetInt("attach",5);
        attach = 5;
        rigid = ball.GetComponent<Rigidbody2D>();
        text = GameObject.Find("Canvas").transform.FindChild("movements");
        text.GetComponent<Text>().text = movements;

    }
}

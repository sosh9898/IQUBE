using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Move_Large : MonoBehaviour
{
    Rigidbody2D rigid;
	static Transform text;
    public float power = 1f;
    private Vector2 Ke;
    private Vector2 currotation;
    private Vector2 worldPoint;
    private Vector2 initMousePos;
    private bool attach = false;
    private int m_count = 0;
    public Text myText;
    string movements="movements : 0";

    void OnMouseDown()
    {
        PlayerPrefs.SetInt("conllsion", 0);
        initMousePos = Input.mousePosition;
        initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);
        currotation = gameObject.transform.position;
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        attach = false;

        if (Mathf.Abs(Ke.x) > Mathf.Abs(Ke.y))
        {
            if (Ke.x > 0)
                gameObject.transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f));
            else
                gameObject.transform.Translate(new Vector3( 0.1f, 0.0f, 0.0f));

        }
        else
        {
            if (Ke.y > 0)
                gameObject.transform.Translate(new Vector3(0.0f, -0.1f, 0.0f));
            else
                gameObject.transform.Translate(new Vector3(0.0f, 0.1f, 0.0f));
        }
        Vector2 afterPo;
        afterPo = gameObject.transform.position;

        int collsion = 0;
        if (PlayerPrefs.HasKey("conllsion")) collsion = PlayerPrefs.GetInt("conllsion");

        if (Mathf.Abs(afterPo.x - currotation.x) + Mathf.Abs(afterPo.y - currotation.y) < 0.3 && collsion!=1)
            m_count--;

        movements = "movements : " + m_count.ToString();
		text.GetComponent<Text>().text = movements;
    }
    void OnMouseUp()
    {
        if (attach == false)
        {
            attach = true;
            m_count++;
            PlayerPrefs.SetInt("m_count", m_count);
            worldPoint = Input.mousePosition;
            worldPoint = Camera.main.ScreenToWorldPoint(worldPoint);


            movements = "movements : " + m_count.ToString();
			text.GetComponent<Text>().text = movements;

            Ke = worldPoint - initMousePos;

            //Debug.Log(worldPoint - initMousePos);

            if (Mathf.Abs(Ke.x) > Mathf.Abs(Ke.y))
            {
                if (Ke.x > 0)
                    rigid.AddForce(Vector2.right * power);//오른쪽
                else
                    rigid.AddForce(Vector2.left * power);//왼쪽

            }
            else
            {
                if (Ke.y > 0)
                    rigid.AddForce(Vector2.up * power); //위쪽
                else
                    rigid.AddForce(Vector2.down * power);// 아래쪽
            }
        
        }
    }


    // Use this for initialization
    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
		text = GameObject.Find("Canvas").transform.FindChild("movements");
		text.GetComponent<Text>().text = movements;

    }
    // Update is called once per frame
    void Update()
    {
    }

}
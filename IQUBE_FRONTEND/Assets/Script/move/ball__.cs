using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ball__ : MonoBehaviour {
    Rigidbody2D rigid;
    private bool attach = false;
    int move = 0;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stars : MonoBehaviour
{
    private Transform star1;
    private Transform star2;
    private Transform star3;
    private Transform star_group;
    private int stagenum;
    private int starn;

    public stars()
    {

    }
    public stars(Transform star_group, Transform star1, Transform star2, Transform star3)
    {
        this.star1 = star1;
        this.star2 = star2;
        this.star_group = star_group;
        this.star3 = star3;
       
    }
    // Use this for initialization
    void Start()
    {
       
        star_group = GameObject.Find("Canvas").transform.FindChild("star_group");
        star1 = star_group.transform.FindChild("star1");
        star2 = star_group.transform.FindChild("star2");
        star3 = star_group.transform.FindChild("star3");
        

    }
    public void vv()
    {
        
        if (PlayerPrefs.HasKey("stageNum")) stagenum = PlayerPrefs.GetInt("stageNum");
        if (PlayerPrefs.HasKey("star" + stagenum))
            starn = PlayerPrefs.GetInt("star" + stagenum);
        else starn = 0;

        if (starn == 0)
        {
			star1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.3f);
			star2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.3f);
			star3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.3f);
        }
        else if (starn == 1)
        {
            star1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
            star2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.3f);
			star3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.3f);
        }
        else if (starn == 2)
        {
            star1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
            star2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
            star3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.3f);
        }
        else if (starn == 3)
        {
            star1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
            star2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
            star3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        }
        star_group.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

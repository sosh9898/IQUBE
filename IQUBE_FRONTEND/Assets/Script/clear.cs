using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clear : MonoBehaviour
{
	private Transform star1;
	private Transform star2;
	private Transform star3;
	private Transform star_group;
	private int starn;
	public GameObject clearUI;
    private int n = 0;
    private int stagenum = 0;
    private Transform cubes;
    private int[] state = new int[96];
    public string x, y;
    private int starting_x,starting_y;

    // Use this for initialization
    void Start()
    {
        if(x.Equals("")&&y.Equals(""))
        {
            starting_x = 0; starting_y=0;
        }
        else
        {
            starting_x = System.Convert.ToInt32(x); starting_y = System.Convert.ToInt32(y);
        }

		star_group = GameObject.Find("Canvas").transform.FindChild("star_group");
		star1 = star_group.transform.FindChild("star1");
		star2 = star_group.transform.FindChild("star2");
		star3 = star_group.transform.FindChild("star3");	

		//PlayerPrefs.DeleteAll();

        for (int n = 0; n <= 95; n++)
        {
                int a = n % 8;
                int b = n / 8;
                cubes = GameObject.Find("cube").transform.FindChild(string.Format("Tile_x{0}_y{1}", a, b));
                if (cubes != null)
                {
                    state[n] = 1;              
                 }else
                 {
                    cubes = GameObject.Find("cube").transform.FindChild(string.Format("final_x{0}_y{1}", a, b));
                if (cubes != null)
                    state[n] = 2;
                else state[n] = 0;
                }

            }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        PlayerPrefs.SetInt("clear_o", 1);
        PlayerPrefs.SetInt("conllsion", 1);
         clearUI.SetActive(true);

        if (PlayerPrefs.HasKey("num")) n = PlayerPrefs.GetInt("num");
            else n = 0;
            if (PlayerPrefs.HasKey("stageNum")) stagenum = PlayerPrefs.GetInt("stageNum");
            else stagenum = 0;


            if (stagenum >= n)
            {
                n = stagenum + 1;
                PlayerPrefs.SetInt("num", n);
            }

            cubeok ak2 = new cubeok(state,starting_x,starting_y);
            int s_min = ak2.start(); // 해당 맵의 최소 이동 횟수 
        
            int m_count = PlayerPrefs.GetInt("m_count"); // 움직인 횟수 
          
            double star = m_count - s_min;
            int b_star = 0;

            if (PlayerPrefs.HasKey("star" + stagenum)) b_star = PlayerPrefs.GetInt("star" + stagenum);

            if (star <= 0)
            {
                PlayerPrefs.SetInt("star" + stagenum, 3);

            }
            else
            {
                star = m_count * 1.2 - s_min;
                if (star <= 0)
                {
                    PlayerPrefs.SetInt("star" + stagenum, 2);
                }
                else
                {
                    PlayerPrefs.SetInt("star" + stagenum, 1);
                }
            }

            int starn = 0;
            if (PlayerPrefs.HasKey("star" + stagenum)) starn = starn = PlayerPrefs.GetInt("star" + stagenum);
            stars a = new stars(star_group, star1, star2, star3);
            a.vv();


            if (b_star > starn) PlayerPrefs.SetInt("star" + stagenum, b_star);
            
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customGame : MonoBehaviour {

    private Transform cubes;
    private int[] stage;
    private GameObject fiD; // final instantiate Demo
    private int s_min; // 해당 맵의 최소 이동 횟수 stage minimum
 //   private int m_count; // 움직인 횟수 moving count 
    // Use this for initialization
    void Start () {

        s_min = 11;
        // 이부분도 받아와야하는뎅
        int idx = -1;
        if (PlayerPrefs.HasKey("cutomIdx")) idx = PlayerPrefs.GetInt("cutomIdx");
        if (idx == -1) {
            //불러오는데 실패하였습니다.

        }
        
        for (int n = 0; n <= 95; n++)
        {
                int x = n % 8;
                int y = n / 8;
                cubes = GameObject.Find("cube").transform.FindChild(string.Format("Tile_x{0}_y{1}", x, y));
                if (cubes != null)
                {
                    if (stage[n] == 1) cubes.gameObject.SetActive(true);
                    else if (stage[n] == 0) cubes.gameObject.SetActive(false);
                    else if (stage[n] == 2)
                    {
                        fiD = GameObject.Find("FinalDestination");
                        fiD = GameObject.Instantiate(fiD, cubes.position, fiD.transform.rotation) as GameObject;
                        fiD.transform.parent = cubes.transform.parent;
                        Instantiate(fiD, cubes.position, fiD.transform.rotation);
                        fiD.name = string.Format("Final_x{0}_y{1}", x, y);
                    }
                
            }
        }
        fiD = GameObject.Find("FinalDestination");
        if (fiD != null)
        {
            Destroy(fiD.gameObject, 0f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}

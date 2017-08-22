using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myMap : MonoBehaviour
{
    /// <summary>
    /// 아이템으로 사용할 오브젝트(프리팹)
    /// </summary>
    public GameObject myItemObject;
    /// <summary>
    /// 아이템이 추가될 오브젝트
    /// </summary>
    public Transform Content;

    /// <summary>
    /// 바인딩할 리스트
    /// </summary>
    public List<Item> ItemList;
    public List<Item> ItemList2;
    public ChatTest A;

    public void makedata()
    {
        // 서버통신
        System.Threading.Thread.Sleep(1000);
        A = new ChatTest();
        List<ChatTest.Data> temp = new List<ChatTest.Data>();
        
        //이 부분만 수정 하면 됨
        temp = A.revChatmy();

        ItemList2 = new List<Item>();

        for (int i = 0; i < temp.Count; i++)
        {
            Debug.Log("ok10");
            Item tempData = new Item();
            tempData.idx = temp[i].idx;
            tempData.Name = temp[i].mapname;
            tempData.User = temp[i].username;
            tempData.Mapsize = temp[i].size;
            tempData.count = temp[i].total_count;
            tempData.rating = temp[i].rating;

            tempData.mapscore = temp[i].mapscore;
            
            tempData.Mode = temp[i].mode;
            tempData.min_ = temp[i].min;
            tempData.OnItemClick = null;
            ItemList2.Add(tempData);
        }
        // 각 데이터 넣는것 


    }
    // Use this for initialization
    void Start()
    {
        makedata();
        this.Binding();
    }

    // Update is called once per frame
    void awake()
    {

    }
    void Update()
    {

    }

    /// <summary>
    /// 아이템 리스트를 지정된 프리팹으로 변환하여 추가합니다.
    /// </summary>
    private void Binding()
    {
        GameObject btnItemTemp;
        myItemObject itemobjectTemp;

        //데이터를 가지고서 프론트에 바인딩 하는 것 데이터 들어가면 itemList2로 변경해야함
        foreach (Item item in this.ItemList2)
        {
            //추가할 오브젝트를 생성한다.
            btnItemTemp = Instantiate(this.myItemObject) as GameObject;
            //오브젝트가 가지고 있는 'ItemObject'를 찾는다.
            itemobjectTemp = btnItemTemp.GetComponent<myItemObject>();

            //각 속성 입력
            //각 속성 입력
            itemobjectTemp.count.text = "시도 횟수 : "+item.count.ToString();
            itemobjectTemp.rate.text = "성공률 : "+(item.rating*100).ToString()+"%";

            itemobjectTemp.mapscore.text = item.mapscore.ToString();

            itemobjectTemp.Name.text = item.Name;
            if (item.Mode == 0)
            {
                if (item.Mapsize == 0)
                {
                    itemobjectTemp.Size.text ="N";
                    item.OnItemClick = new Button.ButtonClickedEvent();
                    item.OnItemClick.AddListener(delegate { ItemClick_Result(item.idx,item); });
                    itemobjectTemp.Item.onClick = item.OnItemClick;

                }
                else
                {
                    itemobjectTemp.Size.text = "<color=#00ff00>"+"L"+"</color>";
                    item.OnItemClick = new Button.ButtonClickedEvent();
                    item.OnItemClick.AddListener(delegate { ItemClick_Result_large(item.idx,item); });
                    itemobjectTemp.Item.onClick = item.OnItemClick;
                }
            }
            else
            {
                itemobjectTemp.Size.text = "<color=#ff0000>"+ "E"+"</color>";
                item.OnItemClick = new Button.ButtonClickedEvent();
                item.OnItemClick.AddListener(delegate { ItemClick_Result_extend_n(item.idx,item); });
                itemobjectTemp.Item.onClick = item.OnItemClick;
            }


            //화면에 추가
            btnItemTemp.transform.SetParent(this.Content);
        }
    }


    /// <summary>
    /// 아이템 클릭
    /// </summary>
    /// 

    /// 

        //movement에는 최소이동횟수를 뿌려주자
    public void ItemClick_Result_extend_n(int idx , Item a)
    {
        int temp = idx;
        PlayerPrefs.SetInt("cutomIdx", temp);
        PlayerPrefs.SetInt("cutomsize", 0);
        PlayerPrefs.SetInt("cutommode", 1);
        PlayerPrefs.SetInt("min_c", a.min_);
        SceneController sc = new SceneController();
        sc.ChangeScene_String("extend_n");
       
    }
    public void ItemClick_Result_large(int idx, Item a)
    {
        int temp = idx;
        PlayerPrefs.SetInt("cutomIdx", temp);
        PlayerPrefs.SetInt("cutomsize", 1);
        PlayerPrefs.SetInt("cutommode", 0);
        PlayerPrefs.SetInt("min_c", a.min_);
        SceneController sc = new SceneController();
        sc.ChangeScene_String("large");
    }

    public void ItemClick_Result(int idx, Item a)
    {
        int temp = idx;
        PlayerPrefs.SetInt("cutomIdx", temp);
        PlayerPrefs.SetInt("cutomsize", 0);
        PlayerPrefs.SetInt("cutommode", 0);
        PlayerPrefs.SetInt("min_c", a.min_);
        SceneController sc = new SceneController();
        sc.ChangeScene_String("normal");
    }
}

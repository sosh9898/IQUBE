using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Main_most : MonoBehaviour
{
	public GameObject l1,l2,l3;
	public cash c;
	public int n;
    /// <summary>
    /// 아이템으로 사용할 오브젝트(프리팹)
    /// </summary>
    public GameObject ItemObject;
    /// <summary>
    /// 아이템이 추가될 오브젝트
    /// </summary>
    public Transform Content;

    public GameObject clear_ok;
    public GameObject mymap_ok;

    private string name_fileed;
    public InputField nameFiled;
    /// <summary>
    /// 바인딩할 리스트
    /// </summary>
    public List<Item> ItemList;

    public List<Item> ItemList4;
    private int kk = 0;
    string userid_ = "";
    public ChatTest A;
    
    public void counts()
    {
        List<ChatTest.mainList> temp = new List<ChatTest.mainList>();

        ChatTest D = new ChatTest();

        temp = D.revChat3();

        ItemList4 = new List<Item>();
        
        for (int i = 0; i < temp.Count; i++)
        {
            Debug.Log("ok10");
            Item tempData = new Item();
            tempData.idx = temp[i].idx;
            tempData.Name = temp[i].mapname;
            tempData.User = temp[i].username;
            tempData.user_id = temp[i].userid;
            tempData.Mapsize = temp[i].size;
            tempData.count = temp[i].total_count;
            tempData.rating = temp[i].rating;
            tempData.Mode = temp[i].mode;
            tempData.mapscore = temp[i].mapscore;
            tempData.played = temp[i].flag;
            tempData.min_ = temp[i].min;
            tempData.OnItemClick = null;
            ItemList4.Add(tempData);
        }
        // 각 데이터 넣는것 
        Binding();
    }
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("userid")) userid_ = PlayerPrefs.GetString("userid");
        System.Threading.Thread.Sleep(1000);
        counts();
    }


    // Update is called once per frame
    void awake()
    {

    }

    public void searching_()
    {

        name_fileed = nameFiled.text;

        if (name_fileed.Equals(""))
        {
            if (nameFiled.text.Equals(""))
            {
                foreach (Transform child in Content)
                {
                    Destroy(child.gameObject, 0f);
                }

                Binding();
            }
        }
        else
        {
            GameObject btnItemTemp;
            ItemObject itemobjectTemp;

            foreach (Transform child in Content)
            {
                Destroy(child.gameObject, 0f);
            }

            foreach (Item item in this.ItemList4)
            {
                if (item.User.Equals(name_fileed)&& item.mapscore > 0)
                {
                    //추가할 오브젝트를 생성한다.
                    btnItemTemp = Instantiate(this.ItemObject) as GameObject;
                    //오브젝트가 가지고 있는 'ItemObject'를 찾는다.
                    itemobjectTemp = btnItemTemp.GetComponent<ItemObject>();
                    //각 속성 입력
                    itemobjectTemp.count.text = "시도 횟수" + item.count.ToString();
                    itemobjectTemp.rate.text = "성공률" + (item.rating * 100).ToString() + "%";

                    itemobjectTemp.Name.text = item.User + "의 " + item.Name;


                    // my map  인 경우
                    if (item.user_id.Equals(userid_) || item.played == 1)
                    {
                        if (item.user_id.Equals(userid_))
                        {
                            itemobjectTemp.my.SetActive(true);
                            itemobjectTemp.check.SetActive(false);

                            if (item.Mode == 0)
                            {
                                if (item.Mapsize == 0)
                                {
                                    itemobjectTemp.Size.text = "N";

                                }
                                else
                                {
                                    itemobjectTemp.Size.text = "<color=#00ff00>" + "L" + "</color>";
                                }
                            }
                            else
                            {
                                itemobjectTemp.Size.text = "<color=#ff0000>" + "E" + "</color>";
                            }

                            item.OnItemClick = new Button.ButtonClickedEvent();
                            item.OnItemClick.AddListener(delegate { mymymy(); });
                            itemobjectTemp.Item.onClick = item.OnItemClick;
                        }
                       else if (item.played == 1)
                        {
                            itemobjectTemp.check.SetActive(true);
                            itemobjectTemp.my.SetActive(false);

                            if (item.Mode == 0)
                            {
                                if (item.Mapsize == 0)
                                {
                                    itemobjectTemp.Size.text = "N";

                                }
                                else
                                {
                                    itemobjectTemp.Size.text = "<color=#00ff00>" + "L" + "</color>";
                                }
                            }
                            else
                            {
                                itemobjectTemp.Size.text = "<color=#ff0000>" + "E" + "</color>";
                            }

                            item.OnItemClick = new Button.ButtonClickedEvent();
                            item.OnItemClick.AddListener(delegate { cleared(); });
                            itemobjectTemp.Item.onClick = item.OnItemClick;
                        }
                    }
                    else
                    {
                        itemobjectTemp.my.SetActive(false);
                        itemobjectTemp.check.SetActive(false);

                        if (item.Mode == 0)
                        {
                            if (item.Mapsize == 0)
                            {
                                itemobjectTemp.Size.text = "N";
                                item.OnItemClick = new Button.ButtonClickedEvent();
                                item.OnItemClick.AddListener(delegate { ItemClick_Result(item.idx, item); });
                                itemobjectTemp.Item.onClick = item.OnItemClick;

                            }
                            else
                            {
                                itemobjectTemp.Size.text = "<color=#00ff00>" + "L" + "</color>";
                                item.OnItemClick = new Button.ButtonClickedEvent();
                                item.OnItemClick.AddListener(delegate { ItemClick_Result_large(item.idx, item); });
                                itemobjectTemp.Item.onClick = item.OnItemClick;
                            }
                        }
                        else
                        {
                            itemobjectTemp.Size.text = "<color=#ff0000>" + "E" + "</color>";
                            item.OnItemClick = new Button.ButtonClickedEvent();
                            item.OnItemClick.AddListener(delegate { ItemClick_Result_extend_n(item.idx, item); });
                            itemobjectTemp.Item.onClick = item.OnItemClick;
                        }

                    }

                    //화면에 추가
                    btnItemTemp.transform.SetParent(this.Content);
                }
            }
            nameFiled.text = "";
        }

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
        ItemObject itemobjectTemp;
        
            //데이터를 가지고서 프론트에 바인딩 하는 것 데이터 들어가면 itemList2로 변경해야함
            foreach (Item item in this.ItemList4)
            {
            if(item.mapscore > 0) { 
            //추가할 오브젝트를 생성한다.
            btnItemTemp = Instantiate(this.ItemObject) as GameObject;
            //오브젝트가 가지고 있는 'ItemObject'를 찾는다.
            itemobjectTemp = btnItemTemp.GetComponent<ItemObject>();
            //각 속성 입력
            itemobjectTemp.count.text = "시도 횟수" + item.count.ToString();
            itemobjectTemp.rate.text = "성공률" + (item.rating * 100).ToString() + "%";

            itemobjectTemp.Name.text = item.User + "의 " + item.Name;


            // my map  인 경우
            if (item.user_id.Equals(userid_) || item.played == 1)
            {
                if (item.user_id.Equals(userid_))
                {
                    itemobjectTemp.my.SetActive(true);
                        itemobjectTemp.check.SetActive(false);

                        if (item.Mode == 0)
                    {
                        if (item.Mapsize == 0)
                        {
                            itemobjectTemp.Size.text = "N";

                        }
                        else
                        {
                            itemobjectTemp.Size.text = "<color=#00ff00>" + "L" + "</color>";
                        }
                    }
                    else
                    {
                        itemobjectTemp.Size.text = "<color=#ff0000>" + "E" + "</color>";
                    }

                    item.OnItemClick = new Button.ButtonClickedEvent();
                    item.OnItemClick.AddListener(delegate { mymymy(); });
                    itemobjectTemp.Item.onClick = item.OnItemClick;
                }
                else if (item.played == 1)
                {
                    itemobjectTemp.check.SetActive(true);
                        itemobjectTemp.my.SetActive(false);

                        if (item.Mode == 0)
                    {
                        if (item.Mapsize == 0)
                        {
                            itemobjectTemp.Size.text = "N";

                        }
                        else
                        {
                            itemobjectTemp.Size.text = "<color=#00ff00>" + "L" + "</color>";
                        }
                    }
                    else
                    {
                        itemobjectTemp.Size.text = "<color=#ff0000>" + "E" + "</color>";
                    }

                    item.OnItemClick = new Button.ButtonClickedEvent();
                    item.OnItemClick.AddListener(delegate { cleared(); });
                    itemobjectTemp.Item.onClick = item.OnItemClick;
                }
            }
            else
            {
                itemobjectTemp.my.SetActive(false);
                itemobjectTemp.check.SetActive(false);

                if (item.Mode == 0)
                {
                    if (item.Mapsize == 0)
                    {
                        itemobjectTemp.Size.text = "N";
                        item.OnItemClick = new Button.ButtonClickedEvent();
                        item.OnItemClick.AddListener(delegate { ItemClick_Result(item.idx, item); });
                        itemobjectTemp.Item.onClick = item.OnItemClick;

                    }
                    else
                    {
                        itemobjectTemp.Size.text = "<color=#00ff00>" + "L" + "</color>";
                        item.OnItemClick = new Button.ButtonClickedEvent();
                        item.OnItemClick.AddListener(delegate { ItemClick_Result_large(item.idx, item); });
                        itemobjectTemp.Item.onClick = item.OnItemClick;
                    }
                }
                else
                {
                    itemobjectTemp.Size.text = "<color=#ff0000>" + "E" + "</color>";
                    item.OnItemClick = new Button.ButtonClickedEvent();
                    item.OnItemClick.AddListener(delegate { ItemClick_Result_extend_n(item.idx, item); });
                    itemobjectTemp.Item.onClick = item.OnItemClick;
                }

            }

            //화면에 추가
            btnItemTemp.transform.SetParent(this.Content);
            }
        }
    }


    /// <summary>
    /// 아이템 클릭
    /// </summary>
    /// 

    public void cleared()
    {
        clear_ok.SetActive(true);
    }
    public void mymymy()
    {
        mymap_ok.SetActive(true);
    }
    public void ItemClick_Result_extend_n(int idx, Item a)
    {
		n = c.money;
		if (n >= 1) {
			l1.SetActive (true);
			l2.SetActive (true);
			int temp = idx;
			PlayerPrefs.SetInt ("cutomIdx", temp);
			PlayerPrefs.SetInt ("cutomsize", 0);
			PlayerPrefs.SetInt ("cutommode", 1);
			PlayerPrefs.SetInt ("min_c", a.min_);
            PlayerPrefs.SetString("producer_", a.user_id);
            n -= 1;
			PlayerPrefs.SetInt ("cash", n);
			SceneController sc = new SceneController ();
			sc.ChangeScene_String ("customgame_extend");
		} else
			l3.SetActive (true);
    }
    public void ItemClick_Result_large(int idx, Item a)
    {
		n = c.money;
		if (n >= 1) {
			l1.SetActive (true);
			l2.SetActive (true);
			int temp = idx;
			PlayerPrefs.SetInt ("cutomIdx", temp);
			PlayerPrefs.SetInt ("cutomsize", 1);
			PlayerPrefs.SetInt ("cutommode", 0);
			PlayerPrefs.SetInt ("min_c", a.min_);
            PlayerPrefs.SetString("producer_", a.user_id);
            n -= 1;
			PlayerPrefs.SetInt ("cash", n);
			SceneController sc = new SceneController ();
			sc.ChangeScene_String ("customgame_large");
		} else
			l3.SetActive (true);
    }

    public void ItemClick_Result(int idx, Item a)
    {
		n = c.money;
		if (n >= 1) {
			l1.SetActive (true);
			l2.SetActive (true);
			int temp = idx;
			PlayerPrefs.SetInt ("cutomIdx", temp);
			PlayerPrefs.SetInt ("cutomsize", 0);
			PlayerPrefs.SetInt ("cutommode", 0);
			PlayerPrefs.SetInt ("min_c", a.min_);
            PlayerPrefs.SetString("producer_", a.user_id);
            n -= 1;
			PlayerPrefs.SetInt ("cash", n);
			SceneController sc = new SceneController ();
			sc.ChangeScene_String ("Test");
		} else
			l3.SetActive (true);
    }
}

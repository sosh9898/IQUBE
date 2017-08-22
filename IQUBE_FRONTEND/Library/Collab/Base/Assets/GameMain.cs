using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
	/// <summary>
	/// 아이템으로 사용할 오브젝트(프리팹)
	/// </summary>
	public GameObject ItemObject;
    /// <summary>
    /// 아이템이 추가될 오브젝트
    /// </summary>
    public Transform Content;

	/// <summary>
	/// 바인딩할 리스트
	/// </summary>
	public List<Item> ItemList;
    private List<Item> ItemList2;
    public ChatTest A; 

    public void makedata()
    {
        // 서버통신
        A = new ChatTest();
        List<ChatTest.Data> temp = A.revChat();


        for (int i = 0; i < temp.Count; i++)
        {

            ItemList2[i].Name = temp[i].id; // 맵 이름
            ItemList2[i].User = temp[i].id; // 유저 이름
            ItemList2[i].Mapsize = temp[i].size; // 0 normal, 1 large
            ItemList2[i].Mode = temp[i].mode; // 0 classic, 1 extend
        }
        // 각 데이터 넣는것 

    }
    // Use this for initialization
    void Start ()
	{
        System.Threading.Thread.Sleep(1500);
        makedata();
        this.Binding();
	}

	// Update is called once per frame
    void awake()
    {
        
    }
	void Update () {

	}

	/// <summary>
	/// 아이템 리스트를 지정된 프리팹으로 변환하여 추가합니다.
	/// </summary>
	private void Binding()
	{
		GameObject btnItemTemp;
		ItemObject itemobjectTemp;

        //데이터를 가지고서 프론트에 바인딩 하는 것 데이터 들어가면 itemList2로 변경해야함
		foreach (Item item in this.ItemList2)
		{
			//추가할 오브젝트를 생성한다.
			btnItemTemp = Instantiate(this.ItemObject) as GameObject;
			//오브젝트가 가지고 있는 'ItemObject'를 찾는다.
			itemobjectTemp = btnItemTemp.GetComponent<ItemObject>();

			//각 속성 입력
			itemobjectTemp.Name.text = item.Name;
			itemobjectTemp.User.text = item.User;
			itemobjectTemp.Mode.text = item.Mode.ToString();
			itemobjectTemp.Item.onClick = item.OnItemClick;

			//화면에 추가
			btnItemTemp.transform.SetParent(this.Content);
		}
	}

 
	/// <summary>
	/// 아이템 클릭
	/// </summary>
	public void ItemClick_Result()
	{
		Debug.Log("아이템이 클릭 되었다.");
      
	}
}

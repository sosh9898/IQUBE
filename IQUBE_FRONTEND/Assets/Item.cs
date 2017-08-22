using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Item
{
    public int idx;
	public string Name;
	public string User;
    public string user_id;
	public int Mode;
    public int min_;
    public int Mapsize;
    public int count;
    public float rating;
    public int played;
    public int mapscore;
    
    /// <summary>
    /// 아이템을 클릭했을때 발생할 이벤트
    /// </summary>
    public Button.ButtonClickedEvent OnItemClick;
}


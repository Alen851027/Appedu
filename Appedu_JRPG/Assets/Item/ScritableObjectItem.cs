using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="道具",menuName ="物品",order =1)]
public class ScritableObjectItem : ScriptableObject
{
    public List<TemplaterItem> templaterItems;
    public void ShowItem() 
    {
        for (int i = 0; i < templaterItems.Count; i++)
        {
            Debug.Log($"道具編號：{templaterItems[i].ItemID}");
            Debug.Log($"道具名稱：{templaterItems[i].ItemName}");
            Debug.Log($"道具類型：{templaterItems[i].types}");
            Debug.Log($"道具售價：{templaterItems[i].Price}");
            Debug.Log("-----------------------------------");
        }
    }
}
[System.Serializable]
public class TemplaterItem
{

    [SerializeField] private string itemName;
    public string ItemName => itemName;
    //[SerializeField] private int objId;
    //public int Obj => objId;
    [SerializeField] private int itemId;
    public int ItemID => itemId;
    [SerializeField] private Sprite itemImg;
    public Sprite ItemImg => itemImg;
    [SerializeField] private int price;
    public int Price => price;
    public ItemType types;

    public enum ItemType
    {
        弓箭,頭盔,鎧甲,手腕,靴子,飾品,消耗品
    }
}

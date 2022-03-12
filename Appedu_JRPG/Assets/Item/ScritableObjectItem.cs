using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="�D��",menuName ="���~",order =1)]
public class ScritableObjectItem : ScriptableObject
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
          �}�b, �Y��, �Z��, ���, �u�l, ���~, ���ӫ~
      }

      public void ShowItem() 
      {
   
      }
}


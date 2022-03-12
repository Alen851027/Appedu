using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "道具集合箱", menuName = "物品集合箱", order = 1)]
public class ScritableObjectItemBox : ScriptableObject
{
    public List<ScritableObjectItem> items;

}

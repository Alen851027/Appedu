using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{

    [CreateAssetMenu(menuName = "Alen/Monster Data" , fileName = "MonsterData")]
    public class MonsterDataSO : ScriptableObject
    {
        [Header("基本資料"), Space(25)]
        [Header("怪物血量")]
        public float Monster_Hp;
        [Header("怪物攻擊")]
        public float Monster_Atk;
        [Header("怪物防禦")]
        public float Monster_Def;
        [Header("怪物爆擊")]
        public float Monster_Critical;


        [Header("怪物經驗值"), Space(25)]
        public int Monster_Exp;

        [Header("怪物金幣"), Space(25)]
        public GameObject Monster_Coin;
        [Header("怪物金幣數量")]
        public int Monster_CoinCount;



        [Header("怪物掉落"), Space(25)]
        public int Monster_Item;
        [Header("怪物掉落機率")]
        public int Monster_ItemProbability;


    }
}

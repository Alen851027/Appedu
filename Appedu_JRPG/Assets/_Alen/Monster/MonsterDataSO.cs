using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{

    [CreateAssetMenu(menuName = "Alen/Monster Data" , fileName = "MonsterData")]
    public class MonsterDataSO : ScriptableObject
    {
        [Header("�򥻸��"), Space(25)]
        [Header("�Ǫ���q")]
        public float Monster_Hp;
        [Header("�Ǫ�����")]
        public float Monster_Atk;
        [Header("�Ǫ����m")]
        public float Monster_Def;
        [Header("�Ǫ��z��")]
        public float Monster_Critical;


        [Header("�Ǫ��g���"), Space(25)]
        public int Monster_Exp;

        [Header("�Ǫ�����"), Space(25)]
        public GameObject Monster_Coin;
        [Header("�Ǫ������ƶq")]
        public int Monster_CoinCount;



        [Header("�Ǫ�����"), Space(25)]
        public int Monster_Item;
        [Header("�Ǫ��������v")]
        public int Monster_ItemProbability;


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Monster;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("怪物資料")]
    private MonsterDataSO dataSO;

    [SerializeField, Header("玩家物件名稱")]
    private string namePlayer = "Player_Archer";

    [SerializeField, Header("追蹤目標範圍")]
    private LayerMask layerTrack;

    private Animator ani;
    private NavMeshAgent nav;
    private Transform traPlayer;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        traPlayer = GameObject.Find(namePlayer).transform;
    }

    private void Update()
    {
        CheckPlayerInTrackRange();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, dataSO.rangeTrack);

        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, dataSO.rangeAttack);
    
    }

    private void CheckPlayerInTrackRange() 
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, dataSO.rangeTrack, layerTrack);
        if (hit.Length > 0)
        {
            print(hit[0].name); 
            MoveToPlayer();
        }
    }

    private void MoveToPlayer() 
    {
        nav.SetDestination(traPlayer.position);
    }
}

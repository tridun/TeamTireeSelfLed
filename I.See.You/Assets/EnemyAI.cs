using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform Player;
    public LayerMask whatIsGround, WhatIsPlayer;

    //Patroling
    public Vector3 WalkPoint;
    bool WalkPointSet;
    public float WalkPointRange;

    //Attacking
    public float TimeBetweenAttacks;
    bool AlreadyAttacked;

    //States
    public float SightRange, AttackRange;
    public bool PlayerInSightRange, PlayerinAttackRange;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Agent = GetComponent<NavMeshAgent>();
    }


    private void Patroling()
    {

    }

    private void Chasing()
    {

    }

    private void Attacking()
    {

    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

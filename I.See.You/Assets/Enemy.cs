using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class Enemy : MonoBehaviour
{
    public NavMeshAgent Gaurd;
    public Transform Player;
    public GameObject Chara;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        Chara = GameObject.FindGameObjectWithTag("Player");
        //"Player";

        
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        


        //Debug.DrawRay(transform.position, transform.forward *10, Color.yellow);



        if (Physics.Raycast(transform.position, transform.forward, out hit,  10))
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                Debug.DrawLine(transform.position, fwd, Color.yellow);
                Debug.Log("There is something in front of the object!");
                Gaurd.SetDestination(Player.position);
            }
        }



    }
}

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
    public bool Triggered = false;
    RaycastHit HitData;

    // Start is called before the first frame update
    void Start()
    {
        //Sets a Game Object to the Player Character.
        Chara = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        if (Triggered == true)
        {
            //Casts a Raycast to see if the player is in sight.
            Physics.Raycast(transform.position, Chara.transform.position - transform.position, out HitData, 10);

            //Checks what tag the collided object is.
            string tag = HitData.collider.tag;

            //If the tag is "Player", begins to chase.
            if (tag == "Player")
            {
                Gaurd.SetDestination(Player.position);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //If Player enters trigger box, activate.
        if (other.gameObject.tag == "Player")
        {
            Triggered = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        //If Player leaves trigger box, deactivate.
        if (other.gameObject.tag == "Player")
        {
            Triggered = false;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class Enemy : MonoBehaviour
{
    private NavMeshAgent Guard;     //Reference to the NavMesh used for the enemy movement.
    private Transform Player;       //Reference to the player's location.
    private GameObject Chara;       //Reference to the player.
    public bool Triggered = false;  //Reference to if an object enters the sight of the enemy. Public as it will be used by other scripts.
    public bool EyeTrig = false;    //Reference for the Eye AI. If the Eye sees the player, this is called.
    public float AttackRange = 1f;  //Reference to the attack range. Public for designing and tersting the range.
    RaycastHit HitData;             //Reference Data from where the Raycast hits

    // Start is called before the first frame update
    void Start()
    {
        //Sets a Game Object to the Player Character.
        Chara = GameObject.FindGameObjectWithTag("Player");
        Player = Chara.transform;
        Guard = GetComponent<NavMeshAgent>();
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

            //Checks the distacne between the enemy and the player
            float HitDis = HitData.distance;

            //If the tag is "Player", begins to chase.
            if (tag == "Player")
            {
                Guard.SetDestination(Player.position);
            }


            //If the player is in range, this is the attack logic.
            if (HitDis <= AttackRange)
            {
                Debug.Log("Hit");
            }
        }

        //This is affected by another script. If the eye sees the player, the bool is true. When it doesn't, the bool is false.
        if (EyeTrig == true)
        {
            Guard.SetDestination(Player.position);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EyeLogic : MonoBehaviour
{
    private Transform Player;        //Reference to the player's location.
    private GameObject Chara;        //Reference to the player.
    private GameObject[] Guard;
    public bool Triggered = false;  //Reference to if an object enters the sight of the enemy. Public as it will be used by other scripts.
    public Enemy EyeTrig;
    RaycastHit HitData;

    // Start is called before the first frame update
    void Start()
    {
        //Sets a Game Object to the Player Character.
        Chara = GameObject.FindGameObjectWithTag("Player");
        Player = Chara.transform;
        Guard = GameObject.FindGameObjectsWithTag("Enemy");

    }


    // Update is called once per frame
    void Update()
    {
        if (Triggered == true)
        {
            //Casts a Raycast to see if the player is in sight.
            Physics.Raycast(transform.position, Chara.transform.position - transform.position, out HitData, 20);
            Debug.DrawRay(transform.position, Chara.transform.position - transform.position);
            //Checks what tag the collided object is.
            string tag = HitData.collider.tag;

            //Checks the distacne between the enemy and the player
            float HitDis = HitData.distance;

            Debug.Log(tag);

            //If the tag is "Player", begins to chase.
            if (tag == "Player")
            {
                foreach (var I in Guard)
                {
                    EyeTrig = I.GetComponent<Enemy>();

                    EyeTrig.EyeTrig = true;
                }
            }

        }
        else
        {
            foreach (var I in Guard)
            {
                EyeTrig = I.GetComponent<Enemy>();

                EyeTrig.EyeTrig = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using System;
public class Enemy : MonoBehaviour
{
    private NavMeshAgent Guard;     //Reference to the NavMesh used for the enemy movement.

    private Transform Player;       //Reference to the player's location.

    private GameObject Chara;       //Reference to the player.

    //public Light SightLight;

    public GameObject[] PatrolPoints;

    private Vector3 PatrolTarget;


    public bool Triggered = false;  //Reference to if an object enters the sight of the enemy. Public as it will be used by other scripts.
    private bool PlayerSeen = false;
    public bool EyeTrig = false;    //Reference for the Eye AI. If the Eye sees the player, this is called.

    public bool RandomPath = false;
    private bool PatrolRange = false;

    public float AttackRange = 1f;  //Reference to the attack range. Public for designing and tersting the range.
    private int Index = 0;
    private bool CanAttack = true;

    public int Damage = 1;

    RaycastHit HitData;             //Reference Data from where the Raycast hits

    // Start is called before the first frame update
    void Start()
    {
        //Sets a Game Object to the Player Character.
        Chara = GameObject.FindGameObjectWithTag("Player");
        Player = Chara.transform;
        Guard = GetComponent<NavMeshAgent>();

        Index = 0;
        //SetDestination();

        PatrolTarget = new Vector3(PatrolPoints[Index].transform.position.x, transform.position.y, PatrolPoints[Index].transform.position.z);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
                if (Guard.remainingDistance <= 1)
                {
                    //Index = Random.Range(0, PatrolPoints.Length - 1);

                    if (PatrolRange == false)
                    {

                        if (RandomPath == true)
                        {
                            //print(Index);
                            if (Random.Range(0, 2) == 0)
                            {
                                Next();
                            }
                            else
                            {

                                Back();

                            }
                        }
                        else
                        {
                            Next();

                        }

                        //StartCoroutine(GaurdReached());

                    }
                }

        


        if (Triggered == true)
        {
            //Casts a Raycast to see if the player is in sight.
            Physics.Raycast(transform.position, Chara.transform.position - transform.position, out HitData, 50);
            Debug.DrawRay(transform.position, Player.transform.position - transform.position);

            //if (HitData.collider.tag != null)
            //{
                //print("hit");
                //Checks what tag the collided object is.
                string tag = HitData.collider.tag;
            //}
            //Checks the distacne between the enemy and the player
            float HitDis = HitData.distance;

            //If the tag is "Player", begins to chase.
            if (tag == "Player")
            {
                PlayerSeen = true;
                //SightLight.color = Color.red;

                Guard.SetDestination(Player.position);

                if (HitDis <= AttackRange)
                {
                    if (CanAttack == true)
                    {
                        StartCoroutine(HitPlayer());
                        print("Ghost");
                    }
                }

            }
            else
            {
                PlayerSeen = false;
                if (EyeTrig == false)
                {
                    //SightLight.color = Color.white;
                    Guard.SetDestination(PatrolTarget);
                }

            }

            //If the player is in range, this is the attack logic.

        }
        else
        {

            if(EyeTrig == false)
            {
                //SightLight.color = Color.white;
                Guard.SetDestination(PatrolTarget);



                //Debug.Log("Hit");
            }

        }

        if(EyeTrig == true)
        {

            //SightLight.color = Color.red;
            //Debug.Log(PlayerSeen);
            //Casts a Raycast to see if the player is in sight.
            //Physics.Raycast(transform.position, Chara.transform.position - transform.position, out HitData, 10);

            //Checks what tag the collided object is.
            //string tag = HitData.collider.tag;

            //Checks the distacne between the enemy and the player
            //float HitDis = HitData.distance;

            Guard.SetDestination(Player.position);

            //if (HitDis <= AttackRange)
            //{
            //    if (CanAttack == true)
            //    {
            //        StartCoroutine(HitPlayer());
            //        print("Ghost");
            //    }
            //}
        }
        else
        {

            if (PlayerSeen == false)
            {
                Guard.SetDestination(PatrolTarget);
            }
        }
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    //If Player enters trigger box, activate.
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Triggered = true;

    //    }
        
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    //If Player leaves trigger box, deactivate.
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Triggered = false;

    //    }
        
    //}

//Sets index to next one.
    void Next()
    {
        Index = Index + 1;
        if (Index > (PatrolPoints.Length - 1))
        {
            Index = 0;
        }
        //Debug.Log("Hit");
        PatrolTarget = new Vector3(PatrolPoints[Index].transform.position.x, transform.position.y, PatrolPoints[Index].transform.position.z);
    }

    //Sets Index to previous one.
    void Back()
    {
        Index--;
        if (Index < 0)
        {
            Index = PatrolPoints.Length - 1;
        }
        PatrolTarget = new Vector3(PatrolPoints[Index].transform.position.x, transform.position.y, PatrolPoints[Index].transform.position.z);
    }

    IEnumerator HitPlayer()
    {
        CanAttack = false;
        Chara.GetComponent<PlayerHealth>().DamagePlayer(Damage);
        yield return new WaitForSeconds(1f);
        CanAttack = true;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EyeLogic : MonoBehaviour
{
    private GameObject Chara;       //Reference to the player.
    public GameObject Projectile;

    private GameObject[] Guard;     //Array for the guard assets
    private GameObject[] WallGuard;

    public bool Triggered = false;  //Reference to if an object enters the sight of the enemy.
    public bool PlayerSeen = false;
    public bool Firing = false;

    public string Tag;

    public float FiringTime = 2f;

    public int Damage = 1;

    private Enemy EyeTrig;           //Sets if the player is in sight or not to the eye.
    private WallEnemy WallTrig;
    public Light EyeLight;

    RaycastHit HitData;             //Reference Data from where the Raycast hits.

    // Start is called before the first frame update
    void Start()
    {
        //Sets a Game Object to the Player Character and adds to guard array.
        Chara = GameObject.FindGameObjectWithTag("Player");
        Guard = GameObject.FindGameObjectsWithTag("Enemy");
        WallGuard = GameObject.FindGameObjectsWithTag("WallEnemy");

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
            Tag = HitData.collider.tag;

            //Checks the distance between the enemy and the player
            float HitDis = HitData.distance;

            //If the tag is "Player", begins to chase.
            if (Tag == "Player")
            {
                if (PlayerSeen == false)
                {
                    float Tri = Time.deltaTime * 3f;

                    //EyeLight.color = Color.Lerp(Color.red, Color.white, Tri);
                }



                PlayerSeen = true; //For Another Script's Logic. True if the player is in sight of the eye.
                if (Firing == false)
                {
                    Firing = true;
                    StartCoroutine(Fired());
                }

                

                foreach (var I in Guard)
                {
                    EyeTrig = I.GetComponent<Enemy>();

                    EyeTrig.EyeTrig = true;
                }
                foreach (var I in WallGuard)
                {
                    WallTrig = I.GetComponent<WallEnemy>();

                    WallTrig.EyeAlarm = true;
                }

            }
            else //Ensures guards don't follow the player's location when not in sight.
            {
                PlayerSeen = false; //For Another Script's Logic
                //EyeLight.color = Color.Lerp(Color.red, Color.white, 5f);
                foreach (var I in Guard)
                {
                    EyeTrig = I.GetComponent<Enemy>();

                    EyeTrig.EyeTrig = false;
                }



                foreach (var I in WallGuard)
                {
                    WallTrig = I.GetComponent<WallEnemy>();

                    WallTrig.EyeAlarm = false;
                }
            }
        }
        else //Ensures guards don't follow the player's location when not in sight.
        {
            PlayerSeen = false;
            //EyeLight.color = Color.Lerp(Color.red, Color.white, 5f);
            foreach (var I in WallGuard)
            {
                WallTrig = I.GetComponent<WallEnemy>();

                //WallTrig.EyeAlarm = false;
            }

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

    IEnumerator Fired()
    {

        yield return new WaitForSeconds(FiringTime);

        GameObject Laser = GameObject.Instantiate(Projectile, transform.position, transform.rotation) as GameObject;
        Laser.GetComponent<LaserLogic>().SetTarget(HitData.point);

        //GameObject.Destroy(Laser, 2F); 


        if (Tag == "Player")
        {
            print(Tag);
            Chara.GetComponent<PlayerHealth>().DamagePlayer(Damage);
        }
        if (Tag == "DestructibleObject")
        {
            Destroy(HitData.transform.gameObject);
        }

        Firing = false;
    }
}

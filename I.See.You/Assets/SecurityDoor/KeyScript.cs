using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    public bool Range = false;
    public GameObject SecurityDoor;
    private SecurityDoorScript Scripts;


    private void Update()
    {

        if (Range == true)
        {
            Scripts = SecurityDoor.GetComponent<SecurityDoorScript>();

            Scripts.KeyFound();


            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            print("Key");
            Range = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Key");
            Range = false;
        }
    }

}

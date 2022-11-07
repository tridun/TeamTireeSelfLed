using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityDoorScript : MonoBehaviour
{
    public GameObject[] Keys;

    private float Control;

    //private bool KeyCollected = false;
    private bool Range = false;

    // Update is called once per frame
    void Update()
    {
        if(Range == true && Input.GetKeyDown(KeyCode.Q) && Control == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            print("Door");
            Range = true;
        }

        Control = Keys.Length;
        foreach (var i in Keys)
        {
            if (i == null)
            {
                Control--;
            }
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Door");
            Range = false;
        }
    }


    //public void KeyFound()
    //{
    //    KeyCollected = true;
    //}



}

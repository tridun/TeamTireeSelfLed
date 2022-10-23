using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityDoorScript : MonoBehaviour
{
    private bool KeyCollected = false;
    private bool Range = false;

    // Update is called once per frame
    void Update()
    {
        if(Range == true && Input.GetKeyDown(KeyCode.Q) && KeyCollected == true)
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
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Door");
            Range = false;
        }
    }


    public void KeyFound()
    {
        KeyCollected = true;
    }



}

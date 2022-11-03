using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public GameObject Guard;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //If Player enters trigger box, activate.
        if (other.gameObject.tag == "Player")
        {
            Guard.GetComponent<Enemy>().Triggered = true;

        }

    }



    private void OnTriggerExit(Collider other)
    {
        //If Player enters trigger box, activate.
        if (other.gameObject.tag == "Player")
        {
            Guard.GetComponent<Enemy>().Triggered = true;

        }

    }


}

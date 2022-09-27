using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioning : MonoBehaviour
{
    // Start is called before the first frame update
    //public float zAxisChange;
    //public float yAxisChange;
    //public GameObject PlayerCamera;

    Animator Anim;

    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Anim.SetTrigger("Active");
        }

        new WaitForSeconds(3);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Anim.SetTrigger("Back");
        }
    }
}

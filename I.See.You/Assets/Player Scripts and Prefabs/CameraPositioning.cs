using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioning : MonoBehaviour
{
    private bool Triggered = false;
    public float ChangeTime = 1f;

    Animator Anim;

    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && Triggered == false)
        {
            StartCoroutine(Set1());
        }

        new WaitForSeconds(3);
        if (Input.GetKeyDown(KeyCode.Alpha1) && Triggered == false)
        {
            StartCoroutine(Set2());
        }
    }

    IEnumerator Set1()
    {
        Anim.SetTrigger("Active");
        //Checks if the routine has been triggered, stops repeated input.
        Triggered = true;
        yield return new WaitForSeconds(ChangeTime);
        Triggered = false;
    }

    IEnumerator Set2()
    {
        Anim.SetTrigger("Back");
        //Checks if the routine has been triggered, stops repeated input.
        Triggered = true;
        yield return new WaitForSeconds(ChangeTime);
        Triggered = false;
    }

}

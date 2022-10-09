using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioning : MonoBehaviour
{
    private bool Triggered = false;     //Allows for control on when the camera moves, as tro not allow for issues.
    public float ChangeTime = 1f;       //Sets Time between activation of camera change

    Animator Anim;                      //Sets Animation Variable

    void Start()
    {
        Anim = gameObject.GetComponent<Animator>(); //Sets ANimation to be played.
    }

    // Update is called once per frame
    void Update()
    {
        //Sets camera into position 2 when the number 1 is pressed. Not on the NumPad.
        if (Input.GetKeyDown(KeyCode.Alpha2) && Triggered == false)
        {
            StartCoroutine(Position1());
        }

        //Sets camera into position 2 when the number 2 is pressed. Not on the NumPad.
        if (Input.GetKeyDown(KeyCode.Alpha1) && Triggered == false)
        {
            StartCoroutine(Position2());
        }
    }

    IEnumerator Position1()
    {
        Anim.SetTrigger("Active"); //Triggers Animation/

        //Checks if the routine has been triggered, stops repeated input.
        Triggered = true;
        yield return new WaitForSeconds(ChangeTime);
        Triggered = false;
    }

    IEnumerator Position2()
    {
        
        Anim.SetTrigger("Back"); //Triggers Animation

        //Checks if the routine has been triggered, stops repeated input.
        Triggered = true;
        yield return new WaitForSeconds(ChangeTime);
        Triggered = false;
    }

}

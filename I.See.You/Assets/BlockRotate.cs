using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotate : MonoBehaviour    
{
    public GameObject Block;
    private bool Triggered = false;
    public float RotateTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Sets cursor to be locked to the window and to be shown.
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    //Checks if the mouse cursor is hovering over the object.
    private void OnMouseOver()
    {
        //Checks if the left mouse button is pressed.
        if (Input.GetMouseButton(0) && Triggered == false)
        {
            //Starts Coroutine for rotating the block to the left.
            StartCoroutine(LeftRotate());
        }

        //Checks if the Right mouse button is pressed.
        if (Input.GetMouseButton(1) && Triggered == false)
        {
            //Starts Coroutine for rotating the block to the right.
            StartCoroutine(RightRotate());
        }
    }

    IEnumerator LeftRotate()
    {
        //Below is an alternative way to rotate the block.
        //Block.transform.rotation = Quaternion.Slerp(Block.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime);

        //Below is a shap rotation of the block.
        Block.transform.Rotate(0, -90, 0);

        //Checks if the routine has been triggered, stops repeated input.
        Triggered = true;
        yield return new WaitForSeconds(RotateTime);
        Triggered = false;
    }

    IEnumerator RightRotate()
    {
        //Below is an alternative way to rotate the block.
        //Block.transform.rotation = Quaternion.Slerp(Block.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime);

        //Below is a shap rotation of the block.
        Block.transform.Rotate(0, 90, 0);

        //Checks if the routine has been triggered, stops repeated input.
        Triggered = true;
        yield return new WaitForSeconds(RotateTime);
        Triggered = false;
    }
}

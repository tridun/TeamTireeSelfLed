using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotate : MonoBehaviour    
{
    public GameObject Block;            //References the block in question
    public GameObject[] RotBlocksAttached;

    private Quaternion BlockRot;

    private bool Triggered = false;     //Controls the input.
    private bool TurningLeft = false;
    private bool TurningRight = false;
    public bool Rotation = false;

    public float RotateTime = 1f;     //Controls time between inputs.
    public float LimitRight = 1f;
    public float LimitLeft = 1f;
    public float MaxRight;
    public float MaxLeft;
    public float TurningRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Sets cursor to be locked to the window and to be shown.
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        BlockRot = transform.rotation;
        TurningRot = transform.rotation.eulerAngles.y;
        print(TurningRot);
    }

    //Checks if the mouse cursor is hovering over the object.
    private void OnMouseOver()
    {
        //Checks if the left mouse button is pressed.
        if (Input.GetMouseButton(0) && Triggered == false && LimitLeft > 0 && LimitLeft < (MaxLeft+1))
        {
            Triggered = true;
            TurningLeft = true;
            Debug.Log("Left");
            LimitLeft = LimitLeft - 1;
            LimitRight = LimitRight + 1;

            if (TurningRot == - 180)
            {
                TurningRot = 180 - 90;
            }
            else
            {
                TurningRot = TurningRot - 90;
            }

            print(TurningRot);
            BlockRot = Quaternion.Euler(BlockRot.x, TurningRot, BlockRot.z);
        }

        //Checks if the Right mouse button is pressed.
        if (Input.GetMouseButton(1) && Triggered == false && LimitRight > 0 && LimitRight < (MaxRight + 1))
        {
            Triggered = true;
            TurningRight = true;
            Debug.Log("Right");
            LimitLeft = LimitLeft + 1;
            LimitRight = LimitRight - 1;

            if (TurningRot == 180)
            {
                TurningRot = -180 + 90;
            }
            else
            {
                TurningRot = TurningRot + 90;
            }

            print(TurningRot);
            BlockRot = Quaternion.Euler(BlockRot.x, TurningRot, BlockRot.z);

            //BlockRot = Quaternion.Euler(BlockRot.x, (BlockRot.eulerAngles.y + 90), BlockRot.z);
        }

        if (TurningLeft == true)
        {
            //Starts Coroutine for rotating the block to the left.
            StartCoroutine(LeftRotate());
            foreach (var I in RotBlocksAttached)
            {
                I.GetComponent<BlockRotate>().TurningLeft = true;
            }

            if (TurningRight == true)
            {
                //Starts Coroutine for rotating the block to the right.
                StartCoroutine(RightRotate());

                foreach (var I in RotBlocksAttached)
                {
                    I.GetComponent<BlockRotate>().TurningRight = true;
                }
            }

        }


    }

    IEnumerator LeftRotate()
    {
        ////Below is an alternative way to rotate the block.
        //Block.transform.rotation = Quaternion.Slerp(Block.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime);


        //print(BlockRot.y);

        Block.transform.Rotate(0, -90, 0); //A shap rotation of the block.
        //transform.rotation = Quaternion.Slerp(transform.rotation, BlockRot, RotateTime);

        TurningLeft = false;
        //Checks if the routine has been triggered, stops repeated input.

        yield return new WaitForSeconds(RotateTime);
        Triggered = false;
        
    }

    IEnumerator RightRotate()
    {
        ////Below is an alternative way to rotate the block.
        //Block.transform.rotation = Quaternion.Slerp(Block.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime);


        //print(BlockRot.y);

        Block.transform.Rotate(0, 90, 0); //A shap rotation of the block.
                                          //transform.rotation = Quaternion.Slerp(transform.rotation, BlockRot, 6 * Time.deltaTime);

        TurningRight = false;
        //Checks if the routine has been triggered, stops repeated input.

        yield return new WaitForSeconds(RotateTime);
        Triggered = false;
        
    }

    IEnumerator LeftRotateOther()
    {
        ////Below is an alternative way to rotate the block.
        //Block.transform.rotation = Quaternion.Slerp(Block.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime);


        //print(BlockRot.y);

        Block.transform.Rotate(0, -90, 0); //A shap rotation of the block.
        //transform.rotation = Quaternion.Slerp(transform.rotation, BlockRot, RotateTime);

        TurningLeft = false;
        //Checks if the routine has been triggered, stops repeated input.

        yield return new WaitForSeconds(RotateTime);
        Triggered = false;

    }

    IEnumerator RightRotateOther()
    {
        ////Below is an alternative way to rotate the block.
        //Block.transform.rotation = Quaternion.Slerp(Block.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime);


        //print(BlockRot.y);

        Block.transform.Rotate(0, 90, 0); //A shap rotation of the block.
                                          //transform.rotation = Quaternion.Slerp(transform.rotation, BlockRot, 6 * Time.deltaTime);

        TurningRight = false;
        //Checks if the routine has been triggered, stops repeated input.

        yield return new WaitForSeconds(RotateTime);
        Triggered = false;

    }
}

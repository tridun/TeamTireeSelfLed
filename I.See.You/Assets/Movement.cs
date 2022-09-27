using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController Control;
    private Vector3 PlayerVelocity;
    private bool GroundedPlayer;
    public float PlayerSpeed = 2.0f;
    private float JumpHeight = 0f;
    private float GravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        Control = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundedPlayer = Control.isGrounded;
        if (GroundedPlayer && PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Control.Move(move * Time.deltaTime * PlayerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        PlayerVelocity.y += GravityValue * Time.deltaTime;
        Control.Move(PlayerVelocity * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController Control;
    private Vector3 PlayerVelocity;
    private bool GroundedPlayer;
    public float PlayerSpeed = 2.0f;
    private float GravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        Control = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Control.transform.rotation = Quaternion.Slerp(Control.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime);
            //Control.transform.Rotate(0, 90, 0);
        }



        GroundedPlayer = Control.isGrounded;
        if (GroundedPlayer && PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = 0f;
        }

        Transform CamTran = Camera.main.transform;

        //Vector3 CamPos = new Vector3(CamTran.position.x, transform.position.y, CamTran.position.z);
        //Vector3 Direction = (transform.position - CamPos).normalized;

        //Vector3 ForMove = Direction * Input.GetAxis("Vertical");
        //Vector3 HorMove = CamTran.right * Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1);

        //Vector3 Move2 = Vector3.ClampMagnitude(ForMove + HorMove, 1);

        //transform.Translate(Move2 * PlayerSpeed * Time.deltaTime, Space.World);

        Control.Move(move * Time.deltaTime * PlayerSpeed);

        //PlayerVelocity.y += GravityValue * Time.deltaTime;
        //Control.Move(PlayerVelocity * Time.deltaTime);
    }
}

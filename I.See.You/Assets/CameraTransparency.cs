using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransparency : MonoBehaviour
{
    //public GameObject Wall1;
    //public GameObject Wall2;
    //
    private GameObject Player;
    private GameObject Wall;
    private GameObject PrevWall;

    public Material[] EnemyChange;

    public float TransparencyValue = 0.5f;

    private bool WallReset = false;


    //public CapsuleCollider Object;
    RaycastHit HitData;             //Reference Data from where the Raycast hits.


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Physics.Raycast(GetComponent<Camera>().transform.position, Player.transform.position - GetComponent<Camera>().transform.position, out HitData, 20);
        Debug.DrawRay(GetComponent<Camera>().transform.position, Player.transform.position - GetComponent<Camera>().transform.position);

        if (HitData.transform.gameObject != Wall)
        {
            PrevWall = Wall;
            WallReset = true;
        }



        if (HitData.collider.tag == "Wall" || HitData.collider.tag == "DestructibleObject" || HitData.collider.tag == "RotationBlocks")
        {
            Wall = HitData.transform.gameObject;

            var WallColors = Wall.GetComponent<MeshRenderer>();
            WallColors.material = EnemyChange[1];

            WallColors.material.color = new Color(WallColors.material.color.r, WallColors.material.color.g, WallColors.material.color.b, TransparencyValue);
        }

        if (WallReset == true && PrevWall!= null)
        {
            PrevWall.GetComponent<MeshRenderer>().material = EnemyChange[0];
            WallReset = false;
        }

    }
}

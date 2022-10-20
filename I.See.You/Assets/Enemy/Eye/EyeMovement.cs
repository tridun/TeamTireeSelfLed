using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMovement : MonoBehaviour
{

    public GameObject[] Points;    //The array of the waypoints.
    private GameObject Player;
    public GameObject EyeSight;

    private Vector3 ChosenPoint;    //The position of the chosen point.
    private Vector3 Return;

    public float MovementSpeed = 2f;

    private Quaternion ReturnRot;

    private int PointIndex = 0;     //Checks which waypoint the script should reference

    public EyeLogic Trig;
    public Movement PlayerMove;
    private WaypointRot WayRot;

    private bool TurnNext = true;
    private bool TurnBack = true;

    private void Awake()
    {
        //Points = GameObject.FindGameObjectsWithTag("Waypoint"); //Adds the waypoijts to the array.
        Player = GameObject.FindGameObjectWithTag("Player");
        EyeSight = GameObject.FindGameObjectWithTag("EyeSight");

        Trig = EyeSight.GetComponent<EyeLogic>();
        PlayerMove = Player.GetComponent<Movement>();

        Return = transform.rotation.eulerAngles;

        ReturnRot = transform.rotation;
        Debug.Log(Return);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Trig.PlayerSeen);

        Vector3 AimPlayer = Player.transform.position - transform.position;
        float RotSpeed = PlayerMove.Walking * Time.deltaTime;

        WayRot = Points[PointIndex].GetComponent<WaypointRot>();

        //Checks if the eye is at the chosen waypoint
        if (transform.position == ChosenPoint)
        {


            //Block.transform.rotation = Quaternion.Slerp(Block.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime)

            if (WayRot.StopAntiClockwise == false && WayRot.StopClockwise == false)
            {

                
                //if (TurnBack == false)
                //{
                //    //Return = new Vector3(Return.x, Return.y + WayRot.RotLeft, Return.z);
                //    ReturnRot = Quaternion.Euler(ReturnRot.x, WayRot.RotLeft, ReturnRot.z);


                    //Randomly choses what the next point is in the list.
                    if (Random.Range(0, 2) == 0)
                    {
                        Next();

                        if (TurnBack == false)
                        {
                            //Return = new Vector3(Return.x, Return.y + WayRot.RotLeft, Return.z);
                            ReturnRot = Quaternion.Euler(ReturnRot.x, WayRot.RotLeft, ReturnRot.z);
                        }
                    }
                    else
                    {
                        Back();

                        if (TurnNext == false)
                        {
                            ReturnRot = Quaternion.Euler(ReturnRot.x, WayRot.RotRight, ReturnRot.z);
                        }
                    }
                //}
            }
            else
            {
                if (WayRot.StopAntiClockwise == true)
                {
                    if (TurnNext == false)
                    {
                        ReturnRot = Quaternion.Euler(ReturnRot.x, WayRot.RotRight, ReturnRot.z);
                    }
                    Back();
                }
                if (WayRot.StopClockwise == true)
                {
                    if (TurnBack == false)
                    {
                        //Return = new Vector3(Return.x, Return.y + WayRot.RotLeft, Return.z);
                        ReturnRot = Quaternion.Euler(ReturnRot.x, WayRot.RotLeft, ReturnRot.z);
                    }
                    Next();
                }
            }
        }
        //Debug.Log(Trig.Firing);

        if (Trig.PlayerSeen == false && Trig.Firing == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, ReturnRot, RotSpeed);

            ChosenPoint = Points[PointIndex].transform.position; //Sets the point the eye is moving to.
            transform.position = Vector3.MoveTowards(transform.position, ChosenPoint, MovementSpeed * Time.deltaTime); //Moves eye to chosen point.
        }
        else
        {
            if (Trig.Tag == "Player")
            {
                Vector3 PlayerDir = Vector3.RotateTowards(transform.forward, AimPlayer, RotSpeed, 0.0f);
                transform.rotation = Quaternion.LookRotation(PlayerDir);
            }
        }


    }




    //Sets index to next one.
    void Next()
    {
        TurnNext = true;
        TurnBack = false;
        print("Left");
        PointIndex++;
        if (PointIndex > (Points.Length - 1))
        {
            PointIndex = 0;
        }
    }

    //Sets Index to previous one.
    void Back()
    {
        TurnBack = true;
        TurnNext = false;
        print("Rigth");
        PointIndex--;
        if (PointIndex < 0)
        {
            PointIndex = Points.Length - 1;
        }
    }
}

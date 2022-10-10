using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMovement : MonoBehaviour
{

    public GameObject[] Points;    //The array of the waypoints.
    private GameObject Player;
    private Vector3 ChosenPoint;    //The position of the chosen point.
    private Vector3 PlayerLocal;
    private Quaternion PlayerRot;
    private Quaternion ReturnRot;
    private int PointIndex = 0;     //Checks which waypoint the script should reference
    public GameObject EyeSight;
    public EyeLogic Trig;

    private void Awake()
    {
        Points = GameObject.FindGameObjectsWithTag("Waypoint"); //Adds the waypoijts to the array.
        Player = GameObject.FindGameObjectWithTag("Player");
        Trig = EyeSight.GetComponent<EyeLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Trig.PlayerSeen);



        //Checks if the eye is at the chosen waypoint
        if (transform.position == ChosenPoint)
        {
            //Randomly choses what the next point is in the list.
            if (Random.Range(0, 2) == 0)
            {
                Next();
            }
            else
            {
                Back();
            }
        }

        if (Trig.PlayerSeen == false)
        {
            ChosenPoint = Points[PointIndex].transform.position; //Sets the point the eye is moving to.
            transform.position = Vector3.MoveTowards(transform.position, ChosenPoint, 2 * Time.deltaTime); //Moves eye to chosen point.
        }
        else
        {
            //PlayerLocal = new Vector3(Player.transform.position.x, transfrom.position.y, Player.transform.position.z) - transform.position;#
            //PlayerRot = Quaternion.LookRotation(-PlayerLocal, Vector3.up);
            //transform.rotation = Quaternion.Slerp(transfrom.rotation, PlayerRot, Time.deltaTime * 2.0f);
        }

    }

    //Sets index to next one.
    void Next()
    {
        PointIndex++;
        if(PointIndex > (Points.Length - 1))
        {
            PointIndex = 0;
        }
    }

    //Sets Index to previous one.
    void Back()
    {
        PointIndex--;
        if (PointIndex < 0)
        {
            PointIndex = Points.Length - 1;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMovement : MonoBehaviour
{

    private GameObject[] Points;    //The array of the waypoints.
    private Vector3 ChosenPoint;    //The position of the chosen point.
    private int PointIndex = 1;     //Checks which waypoint the script should reference

    private void Awake()
    {
        Points = GameObject.FindGameObjectsWithTag("Waypoint"); //Adds the waypoijts to the array.
    }

    // Update is called once per frame
    void Update()
    {
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
        ChosenPoint = Points[PointIndex].transform.position; //Sets the point the eye is moving to.
        transform.position = Vector3.MoveTowards(transform.position, ChosenPoint, 2 * Time.deltaTime); //Moves eye to chosen point.
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

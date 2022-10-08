using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMovement : MonoBehaviour
{

    public GameObject[] Points;
    public Vector3 ChosenPoint;
    public int PointIndex = 1;
    public Transform Eyeball;
    private bool start;

    private void Awake()
    {
        Points = GameObject.FindGameObjectsWithTag("Waypoint");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == ChosenPoint)
        {
            if (Random.Range(0, 2) == 0)
            {
                Next();
            }
            else
            {
                Back();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Next();
        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            Back();
        }
        transform.position = Vector3.MoveTowards(transform.position, ChosenPoint, 2 * Time.deltaTime);
        ChosenPoint = Points[PointIndex].transform.position;
    }

    void Next()
    {
        PointIndex++;
        if(PointIndex > (Points.Length - 1))
        {
            PointIndex = 0;
        }
    }

    void Back()
    {
        PointIndex--;
        if (PointIndex < 0)
        {
            PointIndex = Points.Length - 1;
        }
    }

}

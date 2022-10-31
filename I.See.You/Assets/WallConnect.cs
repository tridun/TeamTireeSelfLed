using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallConnect : MonoBehaviour
{
    public GameObject[] Walls;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var I in Walls)
        {
            I.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
        }
    }
}

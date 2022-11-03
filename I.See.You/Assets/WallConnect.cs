using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallConnect : MonoBehaviour
{
    public GameObject[] Walls;
    private GameObject Camera;
    private bool ConnectChange = false;
    private Material ConMat;


    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        ConMat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.GetComponent<CameraTransparency>().Wall != null)
        {
            //ConMat = GetComponent<MeshRenderer>().material;
            ConnectChange = true;
            foreach (var I in Walls)
            {
                I.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
            }
        }
        else if (this.gameObject != Camera.GetComponent<CameraTransparency>().HitData.transform.gameObject)
        {
            if (ConnectChange == true)
            {
                print("Hit");
                ConnectChange = false;
                foreach (var I in Walls)
                {
                    I.GetComponent<MeshRenderer>().material = ConMat;
                }
            }
        }
    }
}

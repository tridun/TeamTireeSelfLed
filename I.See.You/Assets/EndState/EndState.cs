using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : MonoBehaviour
{
    public GameObject[] Collectibles;
    private GameObject[] EndScreen;

    private float Control;

    public bool TaskForEnd = false;


    // Start is called before the first frame update
    void Start()
    {
        EndScreen = GameObject.FindGameObjectsWithTag("EndScreen");
        Base();

    }

    // Update is called once per frame
    void Update()
    {



    }


    private void OnTriggerEnter(Collider other)
    {
        if (TaskForEnd == true)
        {


            Control = Collectibles.Length;
            foreach (var i in Collectibles)
            {
                if (i == null)
                {
                    Control--;
                }
            }


            if (Control == 0)
            {
                End();
            }
        }
        else
        {
            End();
        }

    }


    public void Base()
    {
        foreach (var i in EndScreen)
        {
            i.SetActive(false);
        }
    }

    public void End()
    {
        foreach (var i in EndScreen)
        {
            i.SetActive(true);
            Time.timeScale = 0;
        }
    }

}

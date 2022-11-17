using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaLogBox : MonoBehaviour
{
    public GameObject X;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            Time.timeScale = 0f;
            X.SetActive(true);
            Destroy(gameObject);
        }
    }
}

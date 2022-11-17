using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiaLogBox : MonoBehaviour
{
    public GameObject X;
    public GameObject Text;

    [TextArea (15, 20)]
    public string DialogueText;

    void Start()
    {
        X = GameObject.FindGameObjectWithTag("Dialogue");
        Text = GameObject.FindGameObjectWithTag("DialogueText");
        X.SetActive(false);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            Text.GetComponent<TextMeshProUGUI>().text = DialogueText;
            Time.timeScale = 0f;
            X.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}

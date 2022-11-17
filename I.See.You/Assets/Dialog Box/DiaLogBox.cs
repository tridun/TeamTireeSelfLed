using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiaLogBox : MonoBehaviour
{
    private GameObject X;
    private GameObject Text;

    public bool ExitState = false;

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
            if (ExitState == false)
            {
                Text.GetComponent<TextMeshProUGUI>().text = DialogueText;
                Time.timeScale = 0f;
                X.SetActive(true);
                Destroy(gameObject);
            }
            else
            {
                Text.GetComponent<TextMeshProUGUI>().text = DialogueText;
                X.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
                X.SetActive(false);
        }
    }
}

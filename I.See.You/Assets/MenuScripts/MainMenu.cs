using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RueLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void SylarLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void ProgrammerTesting()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Debug.Log("Game has been quit");
        Application.Quit();
    }

}

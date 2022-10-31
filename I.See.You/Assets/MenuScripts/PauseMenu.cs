using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject[] PausedObjects;
    // Start is called before the first frame update
    void Start()
    {
        PausedObjects = GameObject.FindGameObjectsWithTag("Paused");
        Time.timeScale = 1;
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //print("Pause");
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                Pause();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                Resume();
            }
        }
    }


    public void Pause()
    {
        foreach (var i in PausedObjects)
        {
            i.SetActive(true);
        }
    }

    public void Resume()
    {
        foreach (var i in PausedObjects)
        {
            i.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Restart()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public bool isPaused;

    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("Pause"))
        {

            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }

    }

    public void Pause()
    {

        pausePanel.SetActive(true);

        Time.timeScale = 0;

        isPaused = true;

    }

    public void Resume()
    {


        Time.timeScale = 1;

        isPaused = false;

        pausePanel.SetActive(false);


       
    }

}
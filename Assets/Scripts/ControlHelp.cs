using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHelp : MonoBehaviour
{
    
    public GameObject controlsHelpScreen;
    public PauseGame pauseGame;
    public GameOver gameOver;
    

    // Update is called once per frame
    void Update()
    {
       


        if (Input.GetButtonDown("Pause"))
        {
            if (pauseGame.isPaused == true && gameOver.isGameOver == true)
            {
                controlsHelpScreen.SetActive(false);
                gameOver.gResume();
                pauseGame.Resume();
            }
            
            
            
        }


    }
}

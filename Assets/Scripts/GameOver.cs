using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool isGameOver;

    public GameObject gameOver;
    public PlayerRespawn playerRespawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Resume"))
        {

            if (isGameOver == true)
            {
                gResume();
            }
           

        }

        if (playerRespawn.isDead == true)
        {
            gPause();
        }

    }

    public void gPause()
    {

        gameOver.SetActive(true);

        Time.timeScale = 0;

        isGameOver = true;

    }

    public void gResume()
    {


        Time.timeScale = 1;

        isGameOver = false;

        gameOver.SetActive(false);



    }
}

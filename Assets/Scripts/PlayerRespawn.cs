using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public Vector3 respawnPoint;
    public PauseGame pauseGame;
    public bool isDead = false;
    


    public void RespawnNow()
    {
        transform.position = respawnPoint;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            isDead = true;
            pauseGame.Pause(); 
            RespawnNow();
            
        }
        else
        {
            isDead = false;
        }

        void Update()
        {
            isDead = false;
        }
    }
}

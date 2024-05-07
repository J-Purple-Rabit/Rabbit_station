using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWallRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;
    public PlayerRespawn respawn;
    public KillWallMovement move;

    public void RespawnNow()
    {
        transform.position = respawnPoint;
        move.FixedUpdate();
        respawn.isDead = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RespawnNow();
        }
    }
    void Update()
    {
        if(respawn.isDead == true)
        {
            RespawnNow();
        }
    }
}

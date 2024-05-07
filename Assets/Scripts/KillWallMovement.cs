using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWallMovement : MonoBehaviour
{

    public Rigidbody2D wallRb;
    public float speed;
    public float input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        wallRb.velocity = new Vector2(input * speed, wallRb.velocity.y);
    } 
}

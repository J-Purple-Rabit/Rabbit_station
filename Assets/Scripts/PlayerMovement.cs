using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{//playerRB refers to the player rigid body, reference to the rigid body component in unity
    public Rigidbody2D playerRb;
    public float speed;
    public float input;
    //reference to the Sprite Renderer component in unity
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    //the following is for the slide, similar to regular movement but just faster.
    public float sSpeed;
    public float sInput;

    public float slideTime;
    public float slideTimeCounter;

    public bool isSliding;

    //this is a regular variable, the f just tells unity theat this value is a float, without it will have problems in unity.#
    //this is because a decimal usually means we are going inside of something, looking into a reference.
    //total amount of time in the air we can jump for.
    public float jumpTIme = 0.35f;

    //the countdown for how long we can stay holding the button.
    public float jumpTimeCounter;

    //vboolean is used to check whether a character is already jumping.
    private bool isJumping;

    //this connects the pause game script so i can use its variables.
    public PauseGame pauseGame;


    // Update is called once per frame
    void Update()
    {

        sInput = Input.GetAxisRaw("Slide");






        //this code geeps track of whether the player wants to go left or right
        input = Input.GetAxisRaw("Horizontal");

        //this controlls wheter the sprite is facing either left or right based upon what button the player preses.
        //imput is only ever equal to -1, 0 or 1. -1 being left, 1 being rigt and 0 is not moving.
        //&& pauseGame.isPaused == false just means that if the game is not paused the sprite should flip, but if the game is paused the sprite will not flip.
        if (input < 0 && pauseGame.isPaused == false)
        {

            spriteRenderer.flipX = true;

        }
        else if (input > 0 && pauseGame.isPaused == false)
        {

            spriteRenderer.flipX = false;

        }


        //returns a true of flase value to whether or not we are on the ground
        //createss an invisible circle 
        //places the circle at the player's feet
        //make the circle the same size as the groundCheckCircle variable
        //then checks to see if that circle overlaps with the ground
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        //this bit of code handles jumping, .velocity is like looking into Player RIgidBody and looking for a value to change.
        if(isGrounded == true && Input.GetButtonDown("Jump"))
        {
            //rsets the is Jumping boolean to true.
            isJumping = true;

            //this resets the jumpTimeCounter every time the jump button is pressed.
            jumpTimeCounter = jumpTIme;

            //this bit of code handles jumping, .velocity is like looking into Player RIgidBody and looking for a value to change.
            playerRb.velocity = Vector2.up * jumpForce;

        }


        //this code allows for a higher jump  if the jump button is held down.
        if (Input.GetButton("Jump") && isJumping == true)
        {
            //our ability to jump will perish when the timer runs out.
            if (jumpTimeCounter > 0)
            {
                playerRb.velocity = Vector2.up * jumpForce;

                //handles ticking down the jump counter, using time. Time.deltaTime is needed to tick in unity.
                jumpTimeCounter -= Time.deltaTime;
            }

            else
            {
                //after the timer is over, sets the isJumping boolean to false, ready for next jump.
                isJumping = false;
            }

          

        }
        //our ability to jump will run out when we lift off the jump button. notice the GetButton"Up"
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }


      

        
        


    }
    //this is similar to Update, however this is checked exactly 50 frames a second this would make the checks more consistent
    void FixedUpdate()
    {
        //Vector2 is an xy value in this case a directional one
        //.velocity in this case is just to set the speed with direction
        //speed input is a variable that can be changed in unity.
        //input has 3 states 0, 1 or -1
        //y value is set as playerRB
        //y value is set to what ever the player's current Rigid body value is, so if a character is falling it will continue to fall and if it is standing still it will continue to stand still.








        playerRb.velocity = new Vector2(input * speed, playerRb.velocity.y);

        if (sInput < 1)
        {
            isSliding = false;
            slideTimeCounter = slideTime;
        }
        else
        {
            isSliding = true;
            
        }
        if (isSliding == true && slideTimeCounter > 0)
        {
            playerRb.velocity = new Vector2(sInput * sSpeed, playerRb.velocity.y);
            slideTimeCounter -= 1;
        }
       



        
          

    }
}

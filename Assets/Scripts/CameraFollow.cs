using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //once agin transform is a component in unity.
    public Transform playerTransform;

    //Vector3 iin unity just has an x, y and z value.
    public Vector3 offset;

    
    public float smoothSpeed = 0.125f;

    //similar to Update method, instead it updates just after the regualar Update method
    private void LateUpdate()
    {
        //the same postition as the player. also + offset includes the offset of the character.
        Vector3 desiredPosition = playerTransform.position + offset;

        //lerp means a linear inrerpolation, it smoothes between two values.
        //*TIme.deltaTime is to make sure the smoothing happens at an even pace.
        //this code takes the current postion of the game object and smoothly ttransitions it into the position of the playerTransform.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        //transform refers to the position of the game object, camoera in this case.
        transform.position = smoothedPosition;



    }



}

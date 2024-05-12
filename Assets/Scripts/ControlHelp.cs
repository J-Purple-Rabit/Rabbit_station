using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHelp : MonoBehaviour
{
    
    public GameObject controlsHelpScreen;

    

    // Update is called once per frame
    void Update()
    {
       


        if (Input.GetButtonDown("Pause"))
        {
            controlsHelpScreen.SetActive(false);
        }


    }
}

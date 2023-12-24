using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPressed : MonoBehaviour
{
void Update()
{
    /*
    if (Input.GetButtonDown("Boost"))
    {
        Debug.Log("Boost button was pressed.");
    }
    if (Input.GetKeyDown(KeyCode.JoystickButton2)) // This corresponds to the Circle button on a PlayStation controller
    {
        Debug.Log("Circle button pressed");
    }

    float forwardTrigger = Input.GetAxis("ForwardTrigger");
    if(forwardTrigger > 0.1f)
    {
        Debug.Log("Trigger is pressed");
    }

    float reverseTrigger = Input.GetAxis("ReverseTrigger");
    if(reverseTrigger > 0.1f)
    {
        Debug.Log("Reverse Trigger is pressed");
    }
    */
    if (Input.GetButton("LeftBumper"))
    {
        // Rotate to the left
        Debug.Log("LeftBumperPressed");
    }

    // Check for right bumper press
    if (Input.GetButton("RightBumper"))
    {
        // Rotate to the right
        Debug.Log("RightBumperPressed");
    }
}

}

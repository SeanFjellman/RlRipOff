using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carJumping : MonoBehaviour
{
    public float jumpHeight = 5.0f;
    public float doublePressTime = 1.5f;
    private float lastPressTime = 0;
    private Rigidbody rb;
    private bool onGround = true;
    private bool canDoubleJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!rb)
        {
            Debug.LogError("Rigidbody component missing!");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (onGround)
            {
                Jump();
                canDoubleJump = true; // Reset double jump ability when on ground
            }
            else if (!onGround && canDoubleJump && (Time.time - lastPressTime < doublePressTime))
            {
                Debug.Log("Double Press Detected, attempting to jump");
                Jump();
                canDoubleJump = false; // Disable double jump until the car lands again
            }
            lastPressTime = Time.time;
        }
    }

    void Jump()
    {
        Debug.Log("Jump called with force: " + (Vector3.up * jumpHeight).ToString());
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}

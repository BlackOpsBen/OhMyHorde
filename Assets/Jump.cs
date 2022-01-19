using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float jumpHeight = 3.0f;

    [SerializeField] private float timeToApex = 1.0f;

    private float initialVelocity;

    private float gravity;

    private bool didJump = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //initialVelocity = (jumpHeight * 2) / timeToApex;

        gravity = (jumpHeight * 2) / Mathf.Pow(timeToApex, 2);

        initialVelocity = Mathf.Sqrt(2 * gravity * jumpHeight);

        rb.gravityScale = -gravity / Physics.gravity.y;
    }

    private void FixedUpdate()
    {
        if (didJump)
        {
            didJump = false;
            rb.velocity += new Vector2(0.0f, initialVelocity);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            didJump = true;
        }
    }
}

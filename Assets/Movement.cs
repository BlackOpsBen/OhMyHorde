using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    [Header("Movement Variables")]
    [SerializeField] private float moveAcceleration = 10.0f;
    [SerializeField] private float maxMoveSpeed = 10.0f;

    private float movementX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Debug.Log("Speed: " + rb.velocity.x);
        animator.SetBool("isRunning", Mathf.Abs(movementX) > float.Epsilon);
    }

    private void UpdateFacing()
    {
        if (movementX < -float.Epsilon)
        {
            sr.flipX = true;
        }
        if (movementX > float.Epsilon)
        {
            sr.flipX = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementX = context.ReadValue<float>();
        UpdateFacing();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Mathf.Abs(rb.velocity.x) < maxMoveSpeed)
        {
            float defaultAmount = Mathf.Abs(movementX * moveAcceleration);
            float diffAmount = maxMoveSpeed - Mathf.Abs(rb.velocity.x);
            float toAdd = Mathf.Min(defaultAmount, diffAmount);
            toAdd = toAdd * Mathf.Sign(movementX);
            rb.velocity += new Vector2(toAdd, 0.0f);
        }
    }
}

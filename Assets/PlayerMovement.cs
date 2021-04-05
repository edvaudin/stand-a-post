using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    SpriteRenderer playerRenderer;
    Rigidbody2D rb;
    

    Vector2 movement;
    Vector2 mousePosition;

    [SerializeField] float speedFactor = 3f;
    [SerializeField] Transform hand;
    [SerializeField] SpriteRenderer weaponRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (movement.magnitude > 0) 
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        if (mousePosition.x - rb.position.x >= 0)
        {
            playerRenderer.flipX = false;
            weaponRenderer.flipY = false;
        }
        else
        {
            playerRenderer.flipX = true;
            weaponRenderer.flipY = true;
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speedFactor * Time.deltaTime);
        RotateHand();
    }

    private void RotateHand()
    {
        Vector2 handPosition = new Vector2(hand.position.x, hand.position.y);
        Vector2 handDirection = mousePosition - handPosition;

        float handAngle = Mathf.Atan2(handDirection.y, handDirection.x) * Mathf.Rad2Deg;

        hand.rotation = Quaternion.Euler(0, 0, handAngle);
    }

}

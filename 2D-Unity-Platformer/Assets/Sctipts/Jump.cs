using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movment : MonoBehaviour
{
    public Rigidbody2D rb;
    public float buttonTime = 0.5f;
    public float jumpHeight = 5;
    public float cancelRate = 100;
    private bool canJump = true;
    public float jumpCooldown = 0.000000001f; 
    float jumpTime;
    bool jumping;
    bool jumpCancelled;
    public Animator animator;
    public float jumpBufferLength;
    private float jumpBufferCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        // rb2d.bodyType = RigidbodyType2D.Kinematic;
        // gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCount = jumpBufferLength;
        }
        else
        {
            jumpBufferCount -= Time.deltaTime;
        }
        if (jumpBufferCount >= 0 && canJump)
        {
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpBufferCount = 0;
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
            animator.SetBool("isJumping",true);
            canJump = false; // Disable jumping
            StartCoroutine(JumpCooldown()); 
        }

        if (jumping)
        {
            
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }

            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if(jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }
    }
    private IEnumerator JumpCooldown()
    {
        
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true; // Re-enable jumping after cooldown
        animator.SetBool("isJumping", false);
    }
    
}
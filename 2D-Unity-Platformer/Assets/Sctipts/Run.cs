using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    private Rigidbody2D rb2d;
    public Animator animator;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float x = Input.GetAxis("Horizontal");
        // float z = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", x);
        Vector2 movement = new Vector2(x, 0);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 7;
        }
        else
        {
            speed = 5;
        }
        transform.Translate(movement * speed * Time.deltaTime);
    }
}

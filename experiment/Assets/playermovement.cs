using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float movespeed = 8;
    public Rigidbody2D rb;
    Vector3 change;
    public Animator animator;

    public bool isAllowedToMove = true;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isAllowedToMove = true;

    }

    // Update is called once per frame
    void Update()
    { //input
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero && isAllowedToMove)
        {
            MoveCharacter();
            animator.SetFloat("Horizontal", change.x);
            animator.SetFloat("Vertical", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }


    }

    void FixedUpdate()
    { // movement
       // rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }

    void MoveCharacter()
    {
        rb.MovePosition(transform.position + change * movespeed * Time.fixedDeltaTime);
    }
}

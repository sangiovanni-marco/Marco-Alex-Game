using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float movespeed = 500f;
    private Vector2 movement;
    private Animator animator;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        rigid.velocity = movement.normalized * movespeed * Time.fixedDeltaTime;
    }

    private void Animate()
    {
        if (movement != Vector2.zero)
        { 
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animate();
    }
}

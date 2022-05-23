using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float movespeed = 500f;
    private Vector2 movement;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
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
            Player.Instance.Animator.SetFloat("X", movement.x);
            Player.Instance.Animator.SetFloat("Y", movement.y);
            Player.Instance.Animator.SetBool("Moving", true);
        }
        else
        {
            Player.Instance.Animator.SetBool("Moving", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animate();
    }
}

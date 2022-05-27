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
        if (Player.Instance.Animator.GetBool("Moving"))
        {
            rigid.velocity = movement.normalized * movespeed * Time.fixedDeltaTime;
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }
    }

    private void Animate()
    {
        if (movement != Vector2.zero && Player.Instance.CooldownCheck())
        {
            Player.Instance.Animator.SetFloat("X", movement.x);
            Player.Instance.Animator.SetFloat("Y", movement.y);
            Player.Instance.Animator.SetBool("Moving", true);

            CheckDirection();
        }
        else
        {
            Player.Instance.Animator.SetBool("Moving", false);
        }
    }

    private void CheckDirection()
    {
        if (movement.y > 0) Debug.Log("Up");
        else if (movement.y < 0) Debug.Log("Down");
        else if (movement.x > 0) Debug.Log("Right");
        else if (movement.x < 0) Debug.Log("Left");
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
        Move();
    }
}

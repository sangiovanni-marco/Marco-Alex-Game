using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private static PlayerMovement instance;
    private Rigidbody2D rigid;
    private float movespeed = 500f;
    private Vector2 movement;
    private string direction = "Down";

    public static PlayerMovement Instance { get => instance; set => instance = value; }
    public string Direction { get => direction; set => direction = value; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

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
        if (movement.y > 0) Direction = "Up";
        else if (movement.y < 0) Direction = "Down";
        else if (movement.x > 0) Direction = "Right";
        else if (movement.x < 0) Direction = "Left";
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
        Move();
    }
}

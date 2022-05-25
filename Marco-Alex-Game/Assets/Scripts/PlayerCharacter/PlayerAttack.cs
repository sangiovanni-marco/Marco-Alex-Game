using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private bool attack = false;
    private float attackSpeed = 0.4f;
    private float staminaCost = 5f;

    public void OnAttack(InputAction.CallbackContext context)
    {
        attack = context.performed;
    }

    private void Attack()
    {
        if(attack 
            && Player.Instance.StaminaCostCheck(staminaCost) 
            && Player.Instance.CooldownCheck())
        {
            Player.Instance.Animator.SetBool("Attacking", true);
            Player.Instance.CooldownTime = attackSpeed;
            Player.Instance.Stamina -= 5;
        }
        else
        {
            Player.Instance.Animator.SetBool("Attacking", false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
}

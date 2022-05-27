using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private bool attack = false;
    private float attackSpeed = 0.4f;
    private float staminaCost = 5f;
    private float damage = 10f;

    [SerializeField] private GameObject[] attackHitboxes;
    private LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.GetMask("Enemy");
    }

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

            Transform hitboxCenter = null;
            switch (PlayerMovement.Instance.Direction)
            {
                case "Down":
                    hitboxCenter = attackHitboxes[0].transform;
                    break;

                case "Up":
                    hitboxCenter = attackHitboxes[1].transform;
                    break;

                case "Right":
                    hitboxCenter = attackHitboxes[2].transform;
                    break;

                case "Left":
                    hitboxCenter = attackHitboxes[3].transform;
                    break;
            }

            Debug.Log(hitboxCenter.position);

            Collider2D[] enemies = Physics2D.OverlapBoxAll(hitboxCenter.position, hitboxCenter.GetComponent<BoxCollider2D>().size, enemyLayer);

            foreach(Collider2D enemy in enemies)
            {
                Debug.Log(enemy.name);
                //enemy.GetComponent<Enemy>().ReceiveDamage(damage);
            }
        }
        else
        {
            Player.Instance.Animator.SetBool("Attacking", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
}

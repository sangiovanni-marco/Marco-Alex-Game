using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float hp;
    private bool invincible = false;
    private float invincibilityTime = 0.2f;

    public virtual void ReceiveDamage(float damage)
    {
        hp -= damage;
        Debug.Log(hp);
        invincible = true;
        if (IsDead())
        {
            Die();
        }
        StartCoroutine("DamageFeedback");
        StartCoroutine("InvincibilityTimer");
    }

    private bool IsDead()
    {
        return hp <= 0;
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }

    public IEnumerator InvincibilityTimer()
    {
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
    }

    public IEnumerator DamageFeedback()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        Color original = sprite.color;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = original;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

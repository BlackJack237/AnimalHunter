using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    
    public float MoveSpeed {
        get { return moveSpeed; }
        set
        {
            moveSpeed = value <-10f || value>10f || value == 0f ? 1f : value;
        }
    }


    public bool IsDead { get; private set; } = false;

    protected float moveSpeed;

    [SerializeField] protected Animator anim;
    [SerializeField] private int health = 10;

    protected Rigidbody2D rb2d;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        Move();
    }

    private void Move()
    {
        rb2d.velocity = new Vector2(-moveSpeed, 0f);
    }

    public void DealDamage (int damage)
    {
        if (IsDead) return;

        health = Mathf.Clamp(health, 0, health - damage);
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log("Anitmator" + anim);
        IsDead = true;
        anim.SetBool("IsDead", IsDead);
        rb2d.velocity = Vector2.zero;
    }
}

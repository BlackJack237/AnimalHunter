using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private int health = 10;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Move();
    }

    private void Move()
    {
        rb2d.velocity = new Vector2(-moveSpeed, 0f);
    }

    public void DealDamage (int damage)
    {
        health = Mathf.Clamp(health, 0, health - damage);
    }
}

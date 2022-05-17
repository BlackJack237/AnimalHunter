using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

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
}
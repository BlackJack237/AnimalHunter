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


    [SerializeField] private int health = 10;
    [SerializeField] private int scorePoints = 0;
    [SerializeField] private AudioClip hitClip;

    protected Rigidbody2D rb2d;
    protected Collider2D animalCollider;
    protected AudioSource source;
    protected Animator anim;
    private Gamemanager gameManager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        animalCollider = GetComponent<Collider2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gamemanager>();
        source = GetComponent<AudioSource>();
        Move();
    }

    private void Move()
    {
        rb2d.velocity = new Vector2(-moveSpeed, 0f);
    }

    public void DealDamage (int damage)
    {
        source.PlayOneShot(hitClip);
        if (IsDead) return;

        health = Mathf.Clamp(health, 0, health - damage);
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        IsDead = true;
        anim.SetBool("IsDead", IsDead);
        rb2d.velocity = Vector2.zero;
        animalCollider.enabled = false;
        StartCoroutine(DestroyAfterTime());
        AddScorePoints();
    }

    private void AddScorePoints()
    {
        gameManager.AddScore(scorePoints);
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}

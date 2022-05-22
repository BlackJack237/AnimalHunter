using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : Animal
{
    [SerializeField] private float fallDownSpeed = 3f;
    public override void Die()
    {
        base.Die();
        rb2d.velocity = new Vector2(-moveSpeed/2, -fallDownSpeed) ;       
    }
}

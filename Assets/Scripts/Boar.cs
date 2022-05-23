using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : Animal
{  
    public override void Die()
    {
        base.Die();
        rb2d.velocity = Vector2.zero;
    }
}

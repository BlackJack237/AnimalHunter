using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : Animal
{
    public override void Die()
    {
        rb2d.velocity = Vector2.zero;
    }
}

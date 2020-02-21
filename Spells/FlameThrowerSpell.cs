using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerSpell : Spell
{
    public override void OnAwake()
    {
        base.OnAwake();
        if (GetLevel() >= 2)
        {
            speed = 20;
        }
    }
}

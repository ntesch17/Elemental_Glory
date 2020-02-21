using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedingModifier : Modifier
{
    public bool moving = false;
    public BleedingModifier()
    {
       // target = player;
        modName = "Bleeding";
        debuff = true;
        damage = true;
        baseAmount = 2;
        amount = 2;
        duration = 3;
        baseDuration = 3;
    }


    public override void UniqueModifier(bool movingPlayer)
    {
        moving = movingPlayer;
        print("worked");
        if (moving)
        {
            duration = 3;
            amount = 5;
        }
        else
        {
            amount = 2;
        }
    }
}

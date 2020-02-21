using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerWyvernModifier : Modifier
{
    public InnerWyvernModifier()
    {
        modName = "Inner Wyvern";
        debuff = false;
        dmgOutput = true;
        duration = -1;
        baseAmount = .2f;
        amount = .2f;
    }

    public override void UniqueModifier(bool flying)
    {
        if (flying)
        {
            amount = baseAmount;
        }
        else
        {
            amount = 0;
        }
    }
}

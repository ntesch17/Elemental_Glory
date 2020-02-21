using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthComboModifier : Modifier
{

    public EarthComboModifier()
    {
        stackable = true;
        modName = "Earth Mastery";
        hps = true;
        baseAmount = 1;
        amount = 1;
        duration = -1;
        debuff = false;
        stacks = 0;


    }

    public override void AddStack()
    {
        base.AddStack();
        amount = baseAmount * stacks;
    }

    public override void OnHittingModifier(Spell spell)
    {
        AddStack();
    }

    public override void RemoveStack()
    {
        base.RemoveStack();
        amount = baseAmount * stacks;
    }


}

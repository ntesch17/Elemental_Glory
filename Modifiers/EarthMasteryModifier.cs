using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMasteryModifier : Modifier
{
    
   public EarthMasteryModifier()
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
    public override void OnHitModifier()
    {
        print("Hit inside of EM");
        AddStack();
        print("Current Stacks: " + stacks);
    }
    public override void RemoveStack()
    {
        base.RemoveStack();
        amount = baseAmount * stacks;
    }


}

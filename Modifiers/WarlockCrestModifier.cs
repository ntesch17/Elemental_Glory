using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarlockCrestModifier : Modifier
{
    public WarlockCrestModifier()
    {
        modName = "Warlock's Crest";
        manaBurn = true;
        duration = -1;
        baseDuration = -1;
        amount = 3;
        baseAmount = 3;
    }

    public override void OnHittingModifier()
    {
        //mana burn
    }
}

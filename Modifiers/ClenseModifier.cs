using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClenseModifier : Modifier
{
   public ClenseModifier()
    {
        modName = Spell.WATER_CLENSE;
        hps = true;
        duration = 3;
        baseDuration = 3;
        baseAmount = 3;
        amount = 3;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBootsModifier : Modifier
{
   public WaterBootsModifier()
    {
        modName = "Boots of Water";
        debuff = false;
        stackable = false;
        waterDmg = true;
        amount = .05f;
        baseAmount = .05f;
        duration = -1;
        baseDuration = -1;
    }
}

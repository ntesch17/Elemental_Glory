using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEssenseModifier : Modifier
{
    public WaterEssenseModifier()
    {
        modName = "Water Essense Modifier";
        debuff = false;
        stackable = false;
        manaCost = true;
        duration = -1;
        baseDuration = -1;
        baseAmount = -.05f;
        amount = -.05f;
    }
}

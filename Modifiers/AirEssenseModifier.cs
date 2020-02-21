using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEssenseModifier : Modifier
{
    public AirEssenseModifier()
    {
        modName = "Air Essense";
        debuff = false;
        stackable = false;
        speedBoost = true;
        baseAmount = .05f;
        amount = .05f;
        baseDuration = -1;
        duration = -1f;
    }
}

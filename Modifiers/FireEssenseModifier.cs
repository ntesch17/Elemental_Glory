using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEssenseModifier : Modifier
{
    public FireEssenseModifier()
    {
        modName = "Fire Essense";
        debuff = false;
        stackable = false;
        fireDmg = true;
        amount = .05f;
        baseAmount = .05f;
        duration = -1;
        baseDuration = -1;
    }
}

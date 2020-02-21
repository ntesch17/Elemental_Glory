using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthEssenseModifier : Modifier
{
   public EarthEssenseModifier()
    {
        modName = "Earth Essense";
        debuff = false;
        damageReduc = true;
        duration = -1;
        baseDuration = -1;
        baseAmount = .05f;
        amount = .05f;
    }
}

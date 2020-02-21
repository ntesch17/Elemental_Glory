using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranquilityEssenseModifier : Modifier
{
    public TranquilityEssenseModifier()
    {
        modName = "Essense of Tranquility";
        damageReduc = true;
        duration =-1;
        baseDuration = -1;
        baseAmount = -.05f;
        amount = -.05f;
    }
}

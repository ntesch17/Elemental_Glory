using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBootsModifier : Modifier
{
    public EarthBootsModifier()
    {
        modName = "Boots of Earth";
        debuff = false;
        stackable = false;
        earthDmg = true;
        amount = .05f;
        baseAmount = .05f;
        duration = -1;
        baseDuration = -1;
    }
}

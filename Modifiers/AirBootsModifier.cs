using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBootsModifier : Modifier
{
    public AirBootsModifier()
    {
        modName = "Boots of Air";
        debuff = false;
        stackable = false;
        windDmg = true;
        amount = .05f;
        baseAmount = .05f;
        duration = -1;
        baseDuration = -1;
    }   
}

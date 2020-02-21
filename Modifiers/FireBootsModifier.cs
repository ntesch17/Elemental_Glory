using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBootsModifier : Modifier
{
    public FireBootsModifier()
    {
        modName = "Boots of Fire";
        debuff = false;
        stackable = false;
        fireDmg = true;
        amount = .05f;
        baseAmount = .05f;
        duration = -1;
        baseDuration = -1;
    }
}

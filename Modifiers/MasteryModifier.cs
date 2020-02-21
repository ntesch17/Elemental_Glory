using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasteryModifier : Modifier
{
    public MasteryModifier()
    {
        modName = "Spell Mastery";
        debuff = false;
        stackable = false;
        cdReduc = true;
        duration = -1;
        baseDuration = -1;
        amount = -.25f;
        baseAmount = -.25f;
    }
}

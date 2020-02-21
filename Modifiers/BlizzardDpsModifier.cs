using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlizzardDpsModifier : Modifier
{
    public BlizzardDpsModifier(float dmg)
    {
        modName = "Blizzard";
        debuff = true;
        damage = true;
        baseDuration = 3;
        duration = 3;
        baseAmount = dmg;
        amount = dmg;
    }

    public BlizzardDpsModifier()
    {
        modName = "Blizzard";
        debuff = true;
        damage = true;
        baseDuration = 3;
        duration = 3;
        baseAmount = 10;
        amount = 10;
    }
}

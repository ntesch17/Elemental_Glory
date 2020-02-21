using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthArmorMod : Modifier
{
    public EarthArmorMod()
    {
        modName = "Earth Armor Buff";
        magicImmune = true;
        baseDuration = 7.5f;
        duration = 7.5f;
    }
}

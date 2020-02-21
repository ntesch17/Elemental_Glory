using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidasModifier : Modifier
{
    public MidasModifier()
    {
        modName = "Midas' Hand";
        gold = true;
        duration = -1;
        baseDuration = -1;
        amount = .1f;
        baseAmount =.1f;
    }
}

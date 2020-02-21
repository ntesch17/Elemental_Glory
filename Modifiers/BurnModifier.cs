using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnModifier : Modifier
{

    public BurnModifier()
    {
        modName = "Burning";
        debuff = true;
        damage = true;
        baseDuration = 3;
        duration = 3;
        baseAmount = 5;
        amount = 5;
    }
  
}

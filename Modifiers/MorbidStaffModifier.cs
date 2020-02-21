using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorbidStaffModifier : Modifier
{
    public MorbidStaffModifier()
    {
        modName = "Morbid Staff";
        lifesteal = true;
        baseDuration =-1;
        duration = -1;
        baseAmount = .1f;
        amount = .1f;
    }
}

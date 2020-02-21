using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeModifier : Modifier
{
   public KnowledgeModifier()
    {
        modName = "Knowledge modifier";
        debuff = false;
        exp = true;
        duration = -1;
        baseDuration = -1;
        amount = .1f;
        baseAmount = .1f;
    }
}

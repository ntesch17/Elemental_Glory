using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HermesSpell : Spell
{
    public override void OnAwake()
    {
        //x2,x3,double jump
        base.OnAwake();
        mod[this.GetLevel() - 1] = mod[this.GetLevel() - 1].Added();
        //mod[this.GetLevel() - 1].duration = this.duration[this.GetLevel() - 1];
        mod[0].amount = .5f;mod[0].baseAmount = .5f;
        mod[1].amount = 1;mod[1].baseAmount = 1;
        mod[2].amount = 1;mod[2].baseAmount = 1;

        this.caster.AddModifier(mod[this.GetLevel() - 1]);
        print("Mod level " + (this.GetLevel()-1) + ": " + mod[this.GetLevel() - 1].modName + ", duration: " + (mod[this.GetLevel() - 1].duration));
        this.GetComponent<FollowObjectWithDif>().followedObject = caster.gameObject;
        this.GetComponent<FollowFlip>().followedObject = caster.gameObject;
        caster.ChangeCast();
    }

    public override void OnDestroy()
    {
        caster.ChangeCast();
        base.OnDestroy();
    }
}

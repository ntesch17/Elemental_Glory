using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthArmorSpell : Spell
{
    public override void OnAwake()
    {
        base.OnAwake();
        //mod[this.GetLevel()].amount = this.GetDamage();
        this.caster.AddModifier(mod[this.GetLevel() - 1]);
        //this.GetComponent<FollowObjectWithDif>().followedObject = caster.gameObject;
    }
}

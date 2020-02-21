using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirShieldSpell : Spell
{
    public Modifier[] SecondMod = new Modifier[3];
    public override void OnAwake()
    {
        base.OnAwake();
        mod[this.GetLevel()-1].creator = this.caster;
        this.caster.AddModifier(mod[this.GetLevel() - 1]);
        SecondMod[this.GetLevel()-1].creator = this.caster;
        //this.caster.AddModifier(SecondMod[this.GetLevel() - 1]);

        /*
         *  if (GetLevel() >= 3)
         {
             caster.GetComponent<JumpLogic>().ChangeFlight();
         }
         * 
         */

        Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), caster.gameObject.GetComponent<Collider2D>());

        if (caster.modifiers.Contains(SecondMod[1]))
        {
            if (caster.modifiers[caster.modifiers.IndexOf(SecondMod[1])].creator == caster)
                caster.RemoveModifier(SecondMod[1]);   
        }
        if (caster.modifiers.Contains(SecondMod[2]))
        {
            if(caster.modifiers[caster.modifiers.IndexOf(SecondMod[2])].creator == caster)
                caster.RemoveModifier(SecondMod[2]);
        }
        this.GetComponent<FollowObjectWithDif>().followedObject = this.caster.gameObject;
    }
    public override void Update()
    {
        //this.GetComponent<FollowObjectWithDif>().followedObject = this.caster.gameObject;
    }
    public override void OnDestroy()
    {
        if (GetLevel() >= 3)
        {
            caster.GetComponent<JumpLogic>().ChangeFlight();
        }
        base.OnDestroy();
    }

    public void ChangeTransparency()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .5f);
        if (GetLevel() >= 3)
        {
            caster.GetComponent<JumpLogic>().ChangeFlight();
        }

        if (caster.modifiers.Contains(SecondMod[1]))
        {
            if (caster.modifiers[caster.modifiers.IndexOf(SecondMod[1])].creator == caster)
                caster.RemoveModifier(SecondMod[1]);
        }
        if (caster.modifiers.Contains(SecondMod[2]))
        {
            if (caster.modifiers[caster.modifiers.IndexOf(SecondMod[2])].creator == caster)
                caster.RemoveModifier(SecondMod[2]);
        }
        //this.GetComponent<FollowObjectWithDif>().x = this.GetComponent<StoreVariables>().var1;
        //this.GetComponent<FollowObjectWithDif>().y = this.GetComponent<StoreVariables>().var2;
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.GetLevel() >= 2)
        {
            if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerController>() != caster)
            {
                collision.gameObject.GetComponent<PlayerController>().AddModifier(SecondMod[this.GetLevel() - 1]);
            }
        }

    }
}

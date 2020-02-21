using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpell : Spell
{
   private void Awake()
    {
        basic = true;
        projectile = true;
        offCooldown = true;
        baseImpactDmg = new float[]{10,15,15};
        impactDmg = new float[] { 10, 15, 15 };
        baseDamage = new float[] { 10, 15, 15 };
        damage = new float[] { 10, 15, 15 };
        //mod = new Modifier[]{null,null, new BurnModifier()};
        manaCost = new float[]{3,3,3};
        duration = new float[]{5,5,5};
        mod[2].creator = caster;
       // print("Modifier name: " + mod[2].modName);
        element = Spell.FIRE_ELEMENT;
       // level = 2;
        speed = 18;
        //setName(Spell.FIRE_BALL);
        //this.OnAwake();
        //print("Fire Ball Mod: " + mod[2].modName);
    }
    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChilledModifier : Modifier
{
    public ChilledModifier()
    {
        modName = "Chilled";
        baseAmount = .1f;
        baseDuration = 3f;
        duration = 3;
        slow = true;
        amount = .10f;
        debuff = true;
    }

    public override void OnHitModifier(Spell spell)
    {
        //print("soakedCollided");
        if (spell.GetElement() == Spell.WATER_ELEMENT)
        {
           // spell.SetDamage(spell.GetDamage() * 1.15f);
            print("WaterMove! Your Frozen");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("soakedCollided");
        if (collision.gameObject.tag == "Spell" && collision.gameObject.GetComponent<Spell>().GetElement() == Spell.WATER_ELEMENT)
        {
            print("WaterMove!!!");
            //collision.gameObject.GetComponent<Spell>().SetDamage(collision.gameObject.GetComponent<Spell>().GetDamage() * (1.15f));
            //GetComponent<PlayerController>().AddModifier(new Frozen());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoakedModifier : Modifier
{
    bool passiveUnlocked = false;
    public SoakedModifier()
    {
        modName = "Soaked";
        baseDuration = 3;
        duration = 3;
        slow = true;
        baseAmount = .10f;
        amount = .10f;
        debuff = true;
    }

    private void Awake()
    {
        print("AH");
    }
    public override void OnHitModifier(Spell spell)
    {
        print("soakedCollided");
        if (spell.GetElement() == Spell.WATER_ELEMENT)
        {
            spell.SetDamage(spell.GetDamage()*1.15f);
            print("WaterMove!!!");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("soakedCollided");
        if(collision.gameObject.tag == "Spell"&&collision.gameObject.GetComponent<Spell>().GetElement()== Spell.WATER_ELEMENT)
        {
            print("WaterMove!!!");
            collision.gameObject.GetComponent<Spell>().SetDamage(collision.gameObject.GetComponent<Spell>().GetDamage()*(1.15f));
            //GetComponent<PlayerController>().AddModifier(new Frozen());
        }
    }
}

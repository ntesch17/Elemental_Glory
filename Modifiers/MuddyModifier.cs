using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuddyModifier : Modifier
{
    public float earthDamageBonus;
    public override void OnHitModifier(Spell spell)
    {
        if (Modifier.CheckElement(spell, Spell.EARTH_ELEMENT))
        {
            spell.damage[spell.GetLevel() - 1] = spell.damage[spell.GetLevel() - 1] * (1 + earthDamageBonus);
        }
    }
}

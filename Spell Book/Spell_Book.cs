using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell_Book : Items
{
    
    public Spell spell;
    public GameObject spell_orb;
    private void Start()
    {
        spellBook = true;
    }

    public override Spell GetSpell()
    {
        return spell;
    }

    public override Spell_Book GetSpellBook()
    {
        return this;
    }

}

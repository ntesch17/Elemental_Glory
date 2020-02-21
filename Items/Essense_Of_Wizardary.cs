using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essense_Of_Wizardary : Items
{
    public float bonusMana;
    public Essense_Of_Wizardary()
    {
        itemName = "Essense of Wizardary";
        consumable = true;
        cost = 250;
        dropRate = .01f;
        chestDropRate = .1f;
    }

    public override void Consume()
    {
        var mana = GetComponent<PlayerController>().GetMaxMana();
        GetComponent<PlayerController>().SetMaxMana(mana + bonusMana);
        base.Consume();
    }
}

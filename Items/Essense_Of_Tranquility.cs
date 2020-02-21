using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essense_Of_Tranquility : Items
{
    public Essense_Of_Tranquility()
    {
        itemName = "Essense of Tranquility";
        bonus = new TranquilityEssenseModifier();
        consumable = true;
        cost = 250;
        dropRate = .01f;
        chestDropRate = .1f;
    }

    public override void Consume()
    {
        GetComponent<PlayerController>().AddModifier(bonus);
        base.Consume();
    }
}

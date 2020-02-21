using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essense_Of_Terasque : Items
{
    public float bonusHp;
    public Essense_Of_Terasque()
    {
        itemName = "Essense of Terasque";
        consumable = true;
        cost = 250;
        dropRate = .01f;
        chestDropRate = .1f;
    }

    public override void Consume()
    {
        var health = GetComponent<PlayerController>().GetMaxHealth();
        GetComponent<PlayerController>().CmdSetMaxHealth(health + bonusHp);
        base.Consume();
    }
}

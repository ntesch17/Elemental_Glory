using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Health_Potion : Items
{
    float healthInc = 20;
   public Item_Health_Potion()
    {
        itemName = "Health Potion";
        consumable = true;
        cost = 50;
        dropRate = .05f;
        chestDropRate = .75f;
        bossDropMultiplier = 2;
    }

    public override void Consume()
    {
        playerEquiped.heal(healthInc);
        base.Consume();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Mana_Potion : Items
{
    float manaInc = 20;
    public Item_Mana_Potion()
    {
        itemName = "Mana Potion";
        consumable = true;
        cost = 50;
        dropRate = .05f;
        chestDropRate = .75f;
        bossDropMultiplier = 2;
    }

    public override void Consume()
    {
        playerEquiped.ManaRecover(manaInc);
        base.Consume();
    }
}

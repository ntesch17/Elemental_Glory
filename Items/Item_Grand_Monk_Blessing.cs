using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Grand_Monk_Blessing : Items
{
    float manaBonus = 30;
    float healthBonus = 30;
    public Item_Grand_Monk_Blessing()
    {
        itemName = "Grand Monk's Blessing";
        cost = 115;
        dropRate = .01f;
        chestDropRate = .4f;
        bossDropMultiplier = 2;
    }
    public override void Consume()
    {
        playerEquiped.heal(healthBonus);
        playerEquiped.ManaRecover(manaBonus);
        base.Consume();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Blessed_Elixir : Items
{
    float manaBonus = 30;
    float healthBonus = 30;
    public Item_Blessed_Elixir()
    {
        itemName = "Blessed Elixir";
        cost = 75;
        dropRate = .05f;
        chestDropRate = .6f;
        bossDropMultiplier = 2;
    }

    public override void Consume()
    {
        playerEquiped.heal(healthBonus);
        playerEquiped.ManaRecover(manaBonus);
        base.Consume();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Warlock_Crest : Items
{
    public Item_Warlock_Crest()
    {
        itemName = "Warlock's Crest";
        bonus = new WarlockCrestModifier();
        cost = 800;
        dropRate = 2.5f;
        chestDropRate = 12.5f;
        bossDropMultiplier = 5;
    }
}

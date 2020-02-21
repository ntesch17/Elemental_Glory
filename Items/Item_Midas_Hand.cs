using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Midas_Hand : Items
{
    public Item_Midas_Hand()
    {
        itemName = "Midas' Hand";
        bonus = new MidasModifier();
        consumable = false;
        cost = 300;
        dropRate = .001f;
        chestDropRate = .1f;
        bossDropMultiplier = 20;
    }
}

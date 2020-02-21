using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Four_Leaf_Clover : Items
{
    public Item_Four_Leaf_Clover()
    {
        itemName = "Four Leaf Clover";
        bonus = new FourLeafCloverModifier();
        consumable = false;
        cost = 300;
        dropRate = .001f;
        chestDropRate = .1f;
        bossDropMultiplier = 20;
    }
}

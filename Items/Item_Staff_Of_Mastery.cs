using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Staff_Of_Mastery : Items
{
    public Item_Staff_Of_Mastery()
    {
        itemName = "Staff of Mastery";
        bonus = new MasteryModifier();
        consumable = false;
        cost = 2400;
        dropRate = .0005f;
        chestDropRate = .01f;
        bossDropMultiplier = 5;
    }
}

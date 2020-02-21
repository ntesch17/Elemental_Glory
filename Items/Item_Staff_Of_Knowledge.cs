using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Staff_Of_Knowledge : Items
{
    public Item_Staff_Of_Knowledge()
    {
        itemName = "Staff of Knowledge";
        bonus = new KnowledgeModifier();
        consumable = false;
        cost = 300;
        dropRate = .001f;
        chestDropRate = .1f;
        bossDropMultiplier = 20;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Morbid_Staff : Items
{
    public Item_Morbid_Staff()
    {
        itemName = "Morbid Staff";
        bonus = new MorbidStaffModifier();
        cost = 1200;
        dropRate = .025f;
        chestDropRate = 12.5f;
        bossDropMultiplier = 5;
    }
}

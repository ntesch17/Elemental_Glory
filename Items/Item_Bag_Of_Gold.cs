using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Bag_Of_Gold : Items
{
    public int goldMinimum = 5;
    public int goldMaximum = 20;
    public Item_Bag_Of_Gold()
    {
        itemName = "Bag o' Gold";
        consumable = true;
        dropRate = 1;
        chestDropRate = .8f;
        bossDropMultiplier = 1;
    }
    public override void AddToInventory(PlayerController player)
    {
        base.AddToInventory(player);
        Consume();
    }
    public override void Consume()
    {
        playerEquiped.AddGold(GetRandomValueBetween(goldMinimum, goldMaximum));
        base.Consume();
    }
    public int GetRandomValueBetween(int low,int high)
    {
        return Random.Range(low,high);
    }
}

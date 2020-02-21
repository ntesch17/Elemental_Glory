using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/*TODO LIST:
 * 25% Cooldown Reduction, Staff of Mastery --
 * Bonus 10% Exp, Staff of Knowledge --
 * Bonus 10% Gold, Midas' Hand --
 * Bonus 5% Luck, 4-Leaf Clover --
 * +10 Max Hp, Essense of Terasque --
 * +5% Dmg Reduc, Essense of Tranquility -
 * +10 Max Mana, Essense of Wizardary -- 
 * +30 Hp, +30 Mana, Grand Monk's
 * +20 Hp, Health Potion
 * +20 Mana, Mana Potion
 * +15 mana/hp, Blessed Elixer
 * Bonus 5% Fire Dmg, Boots of Fire -
 * Bonus 5% Water Dmg, Boots of Water -
 * Bonus 5% Air Dmg, Boots of Air -
 * Bonus 5% Earth Dmg, Boots of Earth - 
 * Use Legendary Token with blank scroll at GrandMaster or Dark Lord, Legendary Token
 * Empower Spell, Empowered Shard
 * Random Legendary Spell, Tome of Legend
 * 5-20 Gold, Bag o' Gold
 * 50-100 Gold, Big Bag o' Gold
 * 10% Life Steal, Morbid Staff
 * 5 Mana Burn on Spell hit, Warlock's Crest
 * Mana per second based on Round
 * Health per second based on Round
 */


public class Items : MonoBehaviour
{
    public PlayerController playerEquiped;
    public int tier;
    public Sprite icon;
    public string itemName;
    public Modifier bonus;
    public bool consumable,spellBook;
    public int cost;
    static int round;
    public float dropRate, chestDropRate, bossDropMultiplier;//percent in decimal form

    public override string ToString()
    {
        if(bonus!=null)
        return itemName + ", " + bonus.ToString();
        else
            return itemName;
    }

    public virtual void AddToInventory(PlayerController playerPickUp)
    {
        playerEquiped = playerPickUp;
        playerEquiped.GetComponent<PlayerController>().AddToInventory(this);
    }
    public virtual void Consume()
    {
        Destroy(this);
    }
    public virtual int GetRound()
    {
        return round;// round will be the actual round soon
    }
    public virtual float GetDropRate()
    {
        return dropRate * round;
    }
    public virtual float GetBossDropRate()
    {
        return (dropRate * round)* bossDropMultiplier;
    }
    public virtual float GetChestDropRate()
    {
        return chestDropRate;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            print("Collided with item");
            // print(this.spell.element + " : " + GetComponent<PlayerController>().name);
            AddToInventory(collision.gameObject.GetComponent<PlayerController>());
            Destroy(this.gameObject);
        }

    }
    public virtual Spell GetSpell()
    {
        return null;
    }
    public virtual Spell_Book GetSpellBook()
    {
        return null;
    }
}

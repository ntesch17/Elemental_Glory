using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*TODO LIST:
 * 25% Cooldown Reduction, Staff of Mastery -
 * Bonus 10% Exp, Staff of Knowledge -
 * Bonus 10% Gold, Midas' Hand - 
 * Bonus 5% Luck, 4-Leaf Clover - 
 * +10 Max Hp, Essense of Terasque - 
 * +5% Dmg Reduc, Essense of Tranquility -
 * +10 Max Mana, Essense of Wizardary - 
 * +30 Hp, +30 Mana, Grand Monk's
 * +20 Hp, Health Potion
 * +20 Mana, Mana Potion
 * +15 mana/hp, Blessed Elixer
 * Bonus 5% Fire Dmg, Boots of Fire
 * Bonus 5% Water Dmg, Boots of Water
 * Bonus 5% Air Dmg, Boots of Air
 * Bonus 5% Earth Dmg, Boots of Earth
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
public class Modifier : MonoBehaviour
{
    public PlayerController creator,target;
    public string modName;
    public bool debuff,stackable;
    public int stacks;
    public bool manaBurn,lifesteal,cdReduc,exp,gold,luck,manaCost,stun,flight,slow,hps,damage,heal,speedBoost,magicImmune,damageReduc, dmgOutput, fireDmg, waterDmg, windDmg, earthDmg, lightningDmg, timeDmg, spaceDmg, minionDmg;
    public float duration,baseDuration;
    public float baseAmount,amount;//shouldnt be used for stun
    //percentage should be in decimal form for amount
//if Duration is 0 it only applies once.
//if Duration is -1 it applies indefinitly(mostly for passives)
/*public Modifier burn = new Modifier
    {
    duration =3,damage = true,debuff = true, amount = 5
   
    };*/

    public static bool CheckElement(Spell spell, string element)
    {
        return (spell.element == element || (spell.mixedSpell && spell.element2 == element));
    }

    public Modifier DeepCopy()
    {
        Modifier other = (Modifier) this.MemberwiseClone();
       
       other.modName = string.Copy(modName);
       return other;
    }

    public Modifier Added()
    {
        duration = baseDuration;
        amount = baseAmount;
        return DeepCopy();
    }
    public override string ToString()
    {
      return modName + ": " + duration + "s, damage/amount: " + amount;
    }

    public virtual void OnHitModifier()//being hit
    {

    }
    public virtual void OnHitModifier(Spell spell)
    {

    }
    public virtual void UniqueModifier()
    {

    }
    public virtual void UniqueModifier(int i)
    {

    }
    public virtual void UniqueModifier(bool boolean)
    {

    }
    public virtual void AddStack()
    {
        stacks++;
    }
    public virtual void AddStack(int i)
    {
        stacks += i;
    }
    public virtual void RemoveStack()
    {
        stacks--;
        if (stacks < 0)
        {
            stacks = 0;
        }
    }
    public virtual void RemoveStack(int i)
    {
        stacks -= i;
        if (stacks < 0)
        {
            stacks = 0;
        }
    }
    public virtual void OnHittingModifier()
    {

    }
    public virtual void OnHittingModifier(Spell spell)
    {

    }
}


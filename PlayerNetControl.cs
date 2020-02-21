using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;




//Read only from here https://answers.unity.com/questions/489942/how-to-make-a-readonly-property-in-inspector.html




public class PlayerNetControl : NetworkBehaviour
{
    public string Name;
    [ReadOnly] [SerializeField] float maxHealth, maxMana, mana, Hps, Mps;

    
    float health;

    public List<Modifier> modifiers;
    Spell LegendarySpell;
    int ID, skillPoints, gold;
    bool alive, second, EMActive;
    Animator anim;
    [ReadOnly] [SerializeField] float modDmgOutput, modDmgInTake, modFireDmg, modWaterDmg, modWindDmg, modEarthDmg, modLightningDmg, modTimeDmg, modSpaceDmg, modMinionDmg, modHeal, modDmg, modSpeed, modHPS = 0;
    float dmgOutput, dmgInTake, fireDmg, waterDmg, windDmg, earthDmg, lightningDmg, timeDmg, spaceDmg, minionDmg;
    PlayerNetControl lastPlayerHit;
    //Iventory inv; //Inventory Script, not yet created



    // Use this for initialization
    void Start()
    {
        modifiers = new List<Modifier>();

        maxHealth = 100;
        maxMana = 100;
        health = 10;
        mana = 10;
        gold = 0;
        Hps = 2;
        Mps = 2;
        skillPoints = 1;
        InvokeRepeating("TwicePerSecond", 0f, .5f);
        //Initalizing Dmg values
        dmgOutput = 1; dmgInTake = 1; waterDmg = 1; fireDmg = 1; windDmg = 1; earthDmg = 1; lightningDmg = 1; timeDmg = 1; spaceDmg = 1; minionDmg = 1;
        modDmgOutput = 1; modDmgInTake = 1; modWaterDmg = 1; modFireDmg = 1; modWindDmg = 1; modEarthDmg = 1; modLightningDmg = 1; modTimeDmg = 1; modSpaceDmg = 1; modMinionDmg = 1; modHPS = 0;
        modHeal = 0;
        modDmg = 0;
        modSpeed = 1;
        //print(Time.fixedDeltaTime);
        // AddModifier(new EarthMasteryModifier());
        // AddModifier(new BleedingModifier());
        // AddModifier(new SoakedModifier());
        AddModifier(new InnerWyvernModifier());
        AddModifier(new EarthEssenseModifier());

    }
    void ResetModifiers()
    {
        modDmgOutput = 1; modDmgInTake = 1; modWaterDmg = 1; modFireDmg = 1; modWindDmg = 1; modEarthDmg = 1; modLightningDmg = 1; modTimeDmg = 1; modSpaceDmg = 1; modMinionDmg = 1; modHPS = 0;
        modHeal = 0;
        modDmg = 0;
        modSpeed = 1;
    }
    // Update is called once per frame
    void Update()
    {
        //ResetModifiers();
        //SumUpModifiers();
    }
    private void FixedUpdate()
    {
        UniqueModifierCheck();
        regenTick();
        ResetModifiers();
        SumUpModifiers();
    }
    void UniqueModifierCheck()
    {
        for (int i = 0; i <= modifiers.Count - 1; i++)
        {
            if (modifiers[i].modName == "Bleeding")
            {
                modifiers[i].UniqueModifier(GetMoving());
            }
            else if (modifiers[i].modName == "Earth Mastery")
            {
                print("EMS Detected");
                // EMActive = true;
                // modifiers[i].modName = "Earth-Mastery";
                //  InvokeRepeating("EarthMasteryLogic", 10f, 10f);
                //modifiers[i].UniqueModifier();
            }
            else if (modifiers[i].modName == "Inner Wyvern")
            {
                modifiers[i].UniqueModifier(GetAirborn());
            }

        }
    }
    void EarthMasteryLogic()
    {
        for (int i = 0; i <= modifiers.Count - 1; i++)
        {
            if (modifiers[i].modName == "Earth Mastery")
            {
                print("Removing a stack");
                modifiers[i].RemoveStack();
                //EMStacks--;
            }
        }
    }
    void TwicePerSecond()
    {
        second = !second;
        // regenTick();
        if (second)
        {

            modifierTick();
        }
    }
    void modifierTick()
    {
        damage(modDmg);
        heal(modHeal);
        applyModifier();
    }
    void SumUpModifiers()
    {
        //print("in sum up");
        if (modifiers.Count != 0)
        {
            //     print("Modifier Size: " + modifiers.Count);
            for (int i = 0; i <= modifiers.Count - 1; i++)
            {
                print(modifiers[i].ToString());
                applyModifier(modifiers[i]);
            }
        }

    }
    void RemoveModifier(Modifier mod)
    {
        modifiers.Remove(mod);
    }
    public void AddModifier(Modifier mod)
    {
        modifiers.Add(mod);
    }
    public float GetMaxMana()
    {
        return maxMana;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public float GetMana()
    {
        return mana;
    }
    public float GetHealth()
    {
        return health;
    }
    void regenTick()
    {
        heal((Hps + modHPS) * Time.fixedDeltaTime);
        ManaRecover(Mps * Time.fixedDeltaTime);
    }
    public void heal(float num)
    {
        health += num;
        if (health > maxHealth)
            health = maxHealth;
    }
    public void damage(float num)
    {
        print("Damaged: " + num);

        health -= num;
        if (health < 0)
            health = 0;
    }
    void ManaRecover(float num)
    {
        mana += num;
        if (mana > maxMana)
            mana = maxMana;
    }
    void ManaBurn(float num)
    {
        float manaBefore = mana;
        mana -= num;
        if (mana < 0)
        {
            mana = 0;
        }
        damage(manaBefore - mana);
    }
    public void applyModifier()
    {
        //Slow/SpeedBoost
        GetComponent<Movement>().SetSpeed(Movement.baseSpeed * modSpeed);


    }
    public void applyModifier(Modifier mod)
    {
        print("in apply modifier");

        if (mod.damageReduc)
            this.modDmgInTake -= mod.amount;

        if (mod.dmgOutput)
            this.modDmgOutput += mod.amount;

        if (mod.stun)
        {
            Stun(mod.duration);
            mod.stun = false;
        }

        if (mod.flight)
        {
            Fly(mod.duration);
            mod.flight = false;
        }
        if (mod.slow)
        {
            this.modSpeed -= mod.amount;
        }

        if (mod.damage)
        {//dmg over time not done yet
            this.modDmg += mod.amount;
        }
        if (mod.fireDmg)
        {
            this.modFireDmg += mod.amount;
        }
        if (mod.waterDmg)
        {
            this.modWaterDmg += mod.amount;
        }
        if (mod.windDmg)
        {
            this.modWindDmg += mod.amount;
        }
        if (mod.earthDmg)
        {
            this.modEarthDmg += mod.amount;
        }
        if (mod.lightningDmg)
        {
            this.modLightningDmg += mod.amount;
        }
        if (mod.timeDmg)
        {
            this.modTimeDmg += mod.amount;
        }
        if (mod.spaceDmg)
        {
            this.modSpaceDmg += mod.amount;
        }
        if (mod.minionDmg)
        {
            this.modMinionDmg += mod.amount;
        }
        if (mod.hps)
        {
            this.modHPS += mod.amount;
        }

        if (mod.heal)
        {//heal over time done yet either
            this.modHeal += mod.amount;
        }
        //  modHeal, modDmg;

        if (mod.speedBoost)
        {
            modSpeed += (mod.amount);
            // just add need to add a method to reduce after duration
        }
        if (mod.magicImmune)
        {
            MagicImmunity(mod.duration);
            mod.magicImmune = false;
            //nullifies debuff modifiers
        }



        if (mod.duration > 0)
            mod.duration = mod.duration - Time.fixedDeltaTime;

        if (mod.duration < 0 && mod.duration > -1)
        {
            modifiers.Remove(mod);
        }
    }
    void Slow(float duration)
    {

    }
    void Stun(float duration)
    {
        //stop movement and cant cast spells
    }
    void Fly(float duration)
    {
        //stop movement and cant cast spells
    }
    void SpeedBoost(float duration)
    {
        //  var newSpeed = GetComponent<Movement>().getSpeed() * mod.amount;

    }
    void MagicImmunity(float duration)
    {

    }
    public void OnBeingHit(Spell spell)//Player being hit
    {
        for (int i = 0; i <= modifiers.Count - 1; i++)
        {
            modifiers[i].OnHitModifier(spell);
            modifiers[i].OnHitModifier();
            if (modifiers[i].modName == "Earth Mastery")
            {
                Invoke("EarthMasteryLogic", 10f);
            }
        }
        this.damage(spell.GetDamage());
    }

    public void onEnemyHit()//Player Hitting someone else
    {

    }
    public bool GetMoving()
    {
        return (GetComponent<Movement>().GetHorizButtonPress() != 0);
    }
    public bool GetAirborn()
    {
        return !GetComponent<JumpLogic>().getOnGround();
    }
}

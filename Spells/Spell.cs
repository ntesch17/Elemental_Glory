using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Spell : NetworkBehaviour
{
    //Element Names
    public static readonly string FIRE_ELEMENT = "Fire", WATER_ELEMENT = "Water", EARTH_ELEMENT = "Earth", AIR_ELEMENT = "Air", ICE_ELEMENT = "Ice", LIGHTNING_ELEMENT = "Lightning", TIME_ELEMENT = "Time", SPACE_ELEMENT = "Space", MINION_ELEMENT = "Minion";
    //Spell Names
    public static readonly string FIRE_BALL= "Fire Ball", FIRE_SHOTGUN = "Fire Spray",FIRE_BOMB = "Fire Bomb", FIRE_STORM = "Fire Storm", FLAME_THROWER = "Flame Thrower", WATER_BALL = "Water Ball", ICE_SHARD = "Ice Shard", WATER_CLENSE = "Water Clense",GRAVE_CHILL = "Grave Chill", BLIZZARD = "Blizzard", MUD_BOMB = "Muddy Bomb",VOLCANO = "Volcano", FIRE_TORNADO = "Fire Tornado", RAIN_CLOUD = "Rain Cloud",
        EARTH_BOULDER="Boulder",EARTH_WALL = "Earth Wall", EARTH_BULLETS = "Earth Bullets", EARTH_ARMOR = "Earth Armor", EARTHQUAKE = "Earthquake",AIR_SLICE = "Air Slice",AIR_HBOOTS = "Hermes Boots",WIND_SLASH = "Wind Slash",WIND_SHEILD = "Wind Sheild",AIR_TWISTER = "Twister";
    public bool projectile,basic,ultimate,mixedSpell;
    public bool applyGravity,unlocked, offCooldown,siphen,thruPlatform,atLocation,nontargetable;
    public bool[] hasModifier = new bool[3];
    public float[] baseImpactDmg = new float[3], impactDmg = new float[3], damage = new float[3], baseDamage = new float[3], duration = new float[3], cooldown = new float[3], manaCost = new float[3];
    public Modifier[] mod = new Modifier[3];
    //public float cooldown;
   // public int level;
    public PlayerController caster;
    public GameObject spellObject;//might be useless? 
    public string element, element2;
    public Image spellIcon;
    public float speed;
    float timeStamp;
    public int level, casterID,spellID;
    public string spellName;

    public virtual void Update()
    {
        var IDmaker = GameObject.Find("Network Manager");
        if (caster == null && casterID != 0)
        {
            //var IDmaker = GameObject.Find("Network Manager");
            caster = IDmaker.GetComponent<IDCreation>().GetPlayer(casterID);
            OnAwake();
            if(!atLocation)
            Physics2D.IgnoreCollision(caster.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        /*
        if (!atLocation)
            Physics2D.IgnoreCollision(IDmaker.GetComponent<IDCreation>().GetPlayer(casterID).GetComponent<Collider2D>(), GetComponent<Collider2D>());*/
    }
    [Command]
    public void CmdDamagePlayer(int playerID, float dmg)
    {
        var IDmaker = GameObject.Find("Network Manager");
        var playerCon = IDmaker.GetComponent<IDCreation>().GetPlayer(playerID);
        playerCon.Damage(dmg);
    }
    public Spell DeepCopy()
    {
        Spell other = (Spell)this.MemberwiseClone();
        //other.IdInfo = new IdInfo(IdInfo.IdNumber);
        other.spellName = string.Copy(spellName);
        return other;
    }
    public void setCaster(PlayerController newCaster)
    {
        caster = newCaster;
    }
    public string getName()
    {
        return spellName;
    }
    public void setLevel(int newLevel)
    {
        level = newLevel;
    }
    public int GetLevel()
    {
        return level;
    }

    public void setName(string name)
    {
        spellName = name;
    }

    public virtual void OnAwake()
    {
        level = caster.GetSpellLevel(spellName);
        print(this.getName() +  " Level : " + this.GetLevel());
        print(spellName + " level: " + level);
        if (mod[0] != null)
            mod[0].creator = this.caster;
        if (mod[1] != null)
            mod[1].creator = this.caster;
        if (mod[2] != null)
            mod[2].creator = this.caster;

        Destroy(this.gameObject, duration[caster.GetComponent<PlayerSpellDirectory>().GetSpellLevel(spellName) - 1]);
    }

    public virtual void OnContact(PlayerController playerHit)
    {
        print("Attempting to give: " + damage[level - 1] + " for level " + (level - 1) + " damage");

        if(hasModifier[level - 1])
            playerHit.AddModifier(GetModifier());

        CmdContactStuff();

        //caster.onEnemyHit(this);
        playerHit.OnBeingHit(this);
    }
    [Command]
    public void CmdContactStuff()
    {
        caster.onEnemyHit(this);
    }
    public string GetElement()
    {
        return element;
    }
    public string GetElement2()
    {
        return element2;
    }
    public float GetDamage()
    {
        return damage[level - 1];
    }
    public void SetDamage(float newDamage)
    {
        damage[level - 1] = newDamage;
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
       // print("Collidied with " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player"&&collision.gameObject.GetComponent<PlayerController>()!=caster)
        {
            OnContact(collision.gameObject.GetComponent<PlayerController>());
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Spell"&&collision.gameObject.GetComponent<Spell>().caster!=caster)
        {
            OnContact(collision.gameObject.GetComponent<RockWall>());
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }

            //Destroy(this.gameObject);
        
    }

    public void StartCooldown()
    {
        timeStamp = Time.time + cooldown[level-1];
    }

    public bool CheckCooldown()
    {
        return timeStamp <= Time.time;
    }
    public Modifier GetModifier()
    {
        print("Level: " + (level) + ", Length: " + mod.Length);
        print("Get Modifier: " + (mod[level - 1]) + ".");

        return mod[level - 1];

    }
    public virtual void SetVariables()
    {

    }
    public virtual void OnDestroy()
    {
        print("Destroyed");
    }
    public virtual void UniqueSpellProperty()
    {

    }
}

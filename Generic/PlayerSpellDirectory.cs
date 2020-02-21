using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerSpellDirectory : NetworkBehaviour
{
    PlayerController player;

   public List<MyKeyValuePair<string, int, float>> directory = new List<MyKeyValuePair<string, int, float>>();
   public override void OnStartClient()
    {
        player = GetComponent<PlayerController>();
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.WATER_BALL, 0,0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.FIRE_BOMB, 0,0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.FIRE_BALL,0,0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.FIRE_SHOTGUN, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.FIRE_STORM, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.FLAME_THROWER, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.ICE_SHARD, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.BLIZZARD, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.WATER_CLENSE, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.EARTH_BOULDER, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.EARTH_WALL, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.EARTH_BULLETS, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.EARTH_ARMOR, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.AIR_HBOOTS, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.AIR_SLICE, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.AIR_TWISTER, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.WIND_SHEILD, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.WIND_SLASH, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.VOLCANO, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.RAIN_CLOUD, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.FIRE_TORNADO, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.MUD_BOMB, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.GRAVE_CHILL, 0, 0));
        directory.Add(new MyKeyValuePair<string, int, float>(Spell.EARTHQUAKE, 0, 0));

        this.IncreaseSpellLevel(Spell.FIRE_BALL);
        this.IncreaseSpellLevel(Spell.FIRE_BALL);
        this.IncreaseSpellLevel(Spell.FIRE_BALL);
        this.IncreaseSpellLevel(Spell.FIRE_SHOTGUN);
        this.IncreaseSpellLevel(Spell.FIRE_SHOTGUN);
        this.IncreaseSpellLevel(Spell.FIRE_SHOTGUN);
        this.IncreaseSpellLevel(Spell.FIRE_BOMB);
        this.IncreaseSpellLevel(Spell.FIRE_BOMB);
        this.IncreaseSpellLevel(Spell.FIRE_BOMB);
        this.IncreaseSpellLevel(Spell.WATER_BALL);
        this.IncreaseSpellLevel(Spell.WATER_BALL);
        this.IncreaseSpellLevel(Spell.WATER_BALL);
        this.IncreaseSpellLevel(Spell.ICE_SHARD);
        this.IncreaseSpellLevel(Spell.ICE_SHARD);
        this.IncreaseSpellLevel(Spell.ICE_SHARD);
        this.IncreaseSpellLevel(Spell.FIRE_STORM);
        this.IncreaseSpellLevel(Spell.WATER_CLENSE);
        this.IncreaseSpellLevel(Spell.WATER_CLENSE);
        this.IncreaseSpellLevel(Spell.WATER_CLENSE);
        this.IncreaseSpellLevel(Spell.BLIZZARD);
        this.IncreaseSpellLevel(Spell.EARTH_BOULDER);
        this.IncreaseSpellLevel(Spell.EARTH_BOULDER);
        this.IncreaseSpellLevel(Spell.EARTH_BOULDER);
        this.IncreaseSpellLevel(Spell.EARTH_WALL);
        this.IncreaseSpellLevel(Spell.EARTH_WALL);
        this.IncreaseSpellLevel(Spell.EARTH_WALL);
        this.IncreaseSpellLevel(Spell.EARTH_WALL);
        this.IncreaseSpellLevel(Spell.EARTH_BULLETS);
        this.IncreaseSpellLevel(Spell.EARTH_BULLETS);
        this.IncreaseSpellLevel(Spell.EARTH_BULLETS);
        this.IncreaseSpellLevel(Spell.EARTH_ARMOR);
        this.IncreaseSpellLevel(Spell.AIR_HBOOTS);
        this.IncreaseSpellLevel(Spell.AIR_HBOOTS);
        this.IncreaseSpellLevel(Spell.AIR_HBOOTS);
        this.IncreaseSpellLevel(Spell.AIR_SLICE);
        this.IncreaseSpellLevel(Spell.AIR_SLICE);
        this.IncreaseSpellLevel(Spell.AIR_SLICE);
        this.IncreaseSpellLevel(Spell.AIR_TWISTER);
        this.IncreaseSpellLevel(Spell.WIND_SHEILD);
        this.IncreaseSpellLevel(Spell.WIND_SHEILD);
        this.IncreaseSpellLevel(Spell.WIND_SHEILD);
        this.IncreaseSpellLevel(Spell.WIND_SLASH);
        this.IncreaseSpellLevel(Spell.WIND_SLASH);
        this.IncreaseSpellLevel(Spell.WIND_SLASH);
        this.IncreaseSpellLevel(Spell.AIR_SLICE);
        this.IncreaseSpellLevel(Spell.AIR_SLICE);
        this.IncreaseSpellLevel(Spell.AIR_SLICE);
        this.IncreaseSpellLevel(Spell.VOLCANO);
        this.IncreaseSpellLevel(Spell.VOLCANO);
       // this.IncreaseSpellLevel(Spell.VOLCANO);
        this.IncreaseSpellLevel(Spell.RAIN_CLOUD);
        this.IncreaseSpellLevel(Spell.RAIN_CLOUD);
        this.IncreaseSpellLevel(Spell.FIRE_TORNADO);
        this.IncreaseSpellLevel(Spell.FIRE_TORNADO);
        this.IncreaseSpellLevel(Spell.MUD_BOMB);
        this.IncreaseSpellLevel(Spell.MUD_BOMB);
        this.IncreaseSpellLevel(Spell.EARTH_ARMOR);
        this.IncreaseSpellLevel(Spell.FLAME_THROWER);
        this.IncreaseSpellLevel(Spell.FLAME_THROWER);
        this.IncreaseSpellLevel(Spell.FLAME_THROWER);
        this.IncreaseSpellLevel(Spell.GRAVE_CHILL);
        this.IncreaseSpellLevel(Spell.GRAVE_CHILL);
        this.IncreaseSpellLevel(Spell.GRAVE_CHILL);
        this.IncreaseSpellLevel(Spell.EARTHQUAKE);
        this.IncreaseSpellLevel(Spell.EARTHQUAKE);
        this.IncreaseSpellLevel(Spell.EARTHQUAKE);
        //this.IncreaseSpellLevel(Spell.GRAVE_CHILL);
    }

    public string GetSpellInfo(string spellName)
    {
        return spellName + " is at level " + GetSpellLevel(spellName) + " and has a current cooldown of " + GetSpellCD(spellName) + "s.";
    }

    public int GetSpellLevel(string spellName)
    {
      for(int i = 0; i<= directory.Count-1; i++)
        {
            if (directory[i].GetKey() == spellName)
            {
                return directory[i].GetValue1();
            }
        }
      return 0;
    }
    public float GetSpellCD(string spellName)
    {
        for (int i = 0; i <= directory.Count - 1; i++)
        {
            if (directory[i].GetKey() == spellName)
            {
                return directory[i].GetValue2();
            }
        }
        return 1;
    }
    public void IncreaseSpellLevel(string spellName)
    {
        for(int i = 0; i <= directory.Count - 1; i++)
        {
            if (directory[i].GetKey() == spellName)
            {
                directory[i].SetValue1(directory[i].GetValue1() +1);
                if (directory[i].GetValue1() >= 4)
                {
                    directory[i].SetValue1(3);
                }
                break;
            }
        }
    }
    public void DecreaseCooldownTimer()
    {
        for (int i = 0; i <= directory.Count - 1; i++)
        {
            if(directory[i].GetValue2()>0){
            directory[i].SetValue2(directory[i].GetValue2()-Time.deltaTime);
            }
        }

    }

    public void SetCooldownTimer(string spellName, float cooldownTime)
    {
        for (int i = 0; i <= directory.Count - 1; i++)
        {
            if (directory[i].GetKey() == spellName)
            {
                directory[i].SetValue2(cooldownTime);
                break;
            }
        }
    }

    private void Update()
    {
        DecreaseCooldownTimer();
    }

    public bool CheckIfOffCooldown(string spellName)
    {
        for (int i = 0; i <= directory.Count - 1; i++)
        {
            if (directory[i].GetKey() == spellName)
            {
                return directory[i].GetValue2()<=0;
               
            }
        }
        return false;
    }


}

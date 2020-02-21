using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spell_IDs : NetworkBehaviour
{
    [SerializeField] [ReadOnly] int FlamethrowerID;
    [SerializeField] [ReadOnly] float speed;
    [SerializeField] [ReadOnly] bool FlamethrowerBool;
    public static List<GameObject> Spells;
    public List<GameObject> GetSpells;//Corresponds with id number

    public void Awake()
    {   for(int i = 0;i<GetSpells.Count;i++)
        {
            GetSpells[i].GetComponent<Spell>().spellID = i;
            if (GetSpells[i].GetComponent<Spell>() == null)
            {
           //     print("i is " + i);
            }

            if (GetSpells[i].GetComponent<Spell>().spellName == Spell.WATER_BALL)
            {
                FlamethrowerID = i;
                FlamethrowerBool = GetSpells[i].GetComponent<Spell>().applyGravity;
            }
          //  print(GetSpells[i].name + ", ID: " + GetSpells[i].GetComponent<Spell>().spellID);
        }
        Spells = GetSpells;
        FlamethrowerID = 0;
        for (int i = 0;i< Spells.Count;i++)
        {
            Spells[i].GetComponent<Spell>().spellID = i;
           // print(Spells[i].name + ", ID: " + Spells[i].GetComponent<Spell>().spellID);
            if (Spells[i].GetComponent<Spell>().spellName == Spell.WATER_BALL)
            {
                speed = Spells[i].GetComponent<Spell>().speed;
                FlamethrowerID = i;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static GameObject GetSpell(int id)
    {

        return Spells[id];
    }
    public static bool SpellGrav(int id)
    {

        return Spells[id].GetComponent<Spell>().applyGravity;
    }
    public static bool SpellLocation(int id)
    {

        return Spells[id].GetComponent<Spell>().atLocation;
    }
    public static bool SpellTarget(int id)
    {

        return Spells[id].GetComponent<Spell>().nontargetable;
    }
    public static float GetSpellSpeed(int id)
    {
        return Spells[id].GetComponent<Spell>().speed;
    }public static string GetSpellName(int id)
    {
        return Spells[id].GetComponent<Spell>().getName();
    }
}

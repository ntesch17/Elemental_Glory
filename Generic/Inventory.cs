using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public List<Slots> itemsInventory = new List<Slots>();
    public Slots[] equipedSpells = new Slots[6];
    public Slots basicSpellSlot = new Slots();
    public int index;
    HotKeyCycle<Slots> hotkeySlots;

    List<Items> equipedItems = new List<Items>(5);
    List<Items> unequipedItems = new List<Items>();
    List<Spell_Book> unequipedSpells = new List<Spell_Book>();
   // List<Spell_Book> equipedSpells = new List<Spell_Book>(4);
    List<Spell_Book> basicSpells = new List<Spell_Book>(2);
    // Start is called before the first frame update

    public void Start()
    {
        hotkeySlots = new HotKeyCycle<Slots>(equipedSpells);
        hotkeySlots.Current().gameObject.GetComponent<Image>().color = Color.red;
    }

    public void Update()
    {
        if (Input.GetButtonDown("InvPrev"))
        {
            PrevSpell();
        }
        else if (Input.GetButtonDown("InvNext"))
        {
            NextSpell();
        }
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            //Cast Spell
            if(GetIfSpell())
            print("Casting Spell Name:" + GetCurrentSpell().name);
            else
                print("No Spell");
        }*/

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetSpellIndex(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetSpellIndex(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetSpellIndex(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetSpellIndex(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetSpellIndex(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SetSpellIndex(5);
        }

        index = hotkeySlots.GetIndex();
    }

    public void AddToInventory(Items item)
    {
        

        for(int i = 0; i < 15; i++)
        {
            if (itemsInventory[i].FreeSlot())
            {
                //print("Slot " + i);
                itemsInventory[i].setItem(item);
                break;
            }
            if (i >= 15)
                print("inventory Full");
        }
        
    }

    public void PrevSpell()
    {
        hotkeySlots.Current().gameObject.GetComponent<Image>().color = Color.white;
        hotkeySlots.Prev();
        hotkeySlots.Current().gameObject.GetComponent<Image>().color = Color.red;
    }
    public void NextSpell()
    {
        hotkeySlots.Current().gameObject.GetComponent<Image>().color = Color.white;
        hotkeySlots.Next();
        hotkeySlots.Current().gameObject.GetComponent<Image>().color = Color.red;
    }

    public void SetSpellIndex(int i)
    {
        hotkeySlots.Current().gameObject.GetComponent<Image>().color = Color.white;
        hotkeySlots.SetIndex(i);
        hotkeySlots.Current().gameObject.GetComponent<Image>().color = Color.red;
    }
    
    public Spell GetCurrentSpell()
    { 
        return hotkeySlots.Current().item.GetSpell();
    }
    public Spell_Book GetCurrentSpellBook()
    {
        return hotkeySlots.Current().item.GetSpellBook();
    }
    public bool GetIfSpell()
    {
        if(!hotkeySlots.Current().FreeSlot())
        return hotkeySlots.Current().item.spellBook;
        else
        return false;
    } public Spell GetCurrentSpell2()
    { 
        return basicSpellSlot.item.GetSpell();
    }
    public Spell_Book GetCurrentSpellBook2()
    {
        return basicSpellSlot.item.GetSpellBook();
    }
    public bool GetIfSpell2()
    {
        if(!basicSpellSlot.FreeSlot())
        return basicSpellSlot.item.spellBook;
        else
        return false;
    }

}

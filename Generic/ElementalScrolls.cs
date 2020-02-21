using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ElementalScrolls : MonoBehaviour
     , IPointerClickHandler 
     
{
    public Sprite FireScroll, WaterScroll, WindScroll, EarthScroll,thisSprite;
    public Shop shop;
    public GameObject storedSpell;
    public bool spells;
    // Start is called before the first frame update
    void Start()
    {
        thisSprite = GetComponent<Image>().sprite;
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        shop.SetSeletectedSpell(storedSpell);
        // holdingItem = TakeItem();

    }
    public void SetStoredSpell(GameObject spellToBeStored)
    {
        storedSpell = spellToBeStored;
        if(spells)
        {
            if(storedSpell.GetComponent<Spell_Book>().spell.element == Spell.FIRE_ELEMENT)
            {
                thisSprite = FireScroll;
            }
            else if(storedSpell.GetComponent<Spell_Book>().spell.element == Spell.WATER_ELEMENT)
            {
                thisSprite = WaterScroll;
            }
            else if(storedSpell.GetComponent<Spell_Book>().spell.element == Spell.EARTH_ELEMENT)
            {
                thisSprite = EarthScroll;

            }
            else
            {
                thisSprite = WindScroll;
            }
            GetComponent<Image>().sprite = thisSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

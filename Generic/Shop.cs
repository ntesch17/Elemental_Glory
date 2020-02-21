using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public List<GameObject> spellInventory,tier0, tier1, tier2, tier3,tier4;
    public GameObject[] shownSpells, shownItems;
    public GameObject selectedItem,thisItem;
    public Canvas shopCanvas;
    public ElementalScrolls spellSlot1, spellSlot2, spellSlot3, spellSlot4;
    public bool inside;

    // Start is called before the first frame update
    void Start()
    {
        shopCanvas.gameObject.SetActive(false);
        spellSlot1 = shopCanvas.transform.GetChild(0).GetChild(0).GetComponent<ElementalScrolls>();
        spellSlot2 = shopCanvas.transform.GetChild(0).GetChild(1).GetComponent<ElementalScrolls>();
        spellSlot3 = shopCanvas.transform.GetChild(0).GetChild(2).GetComponent<ElementalScrolls>();
        spellSlot4 = shopCanvas.transform.GetChild(0).GetChild(3).GetComponent<ElementalScrolls>();

        SetTier();

        GiveOutScrolls();
    }
    public void SetTier()
    {
        foreach(GameObject spellBook in spellInventory)
        {
            if(spellBook.GetComponent<Spell_Book>().tier == 0)
            {
                tier0.Add(spellBook);
            }
            else if (spellBook.GetComponent<Spell_Book>().tier == 1)
            {
                tier1.Add(spellBook);
            }
            else if (spellBook.GetComponent<Spell_Book>().tier == 2)
            {
                tier2.Add(spellBook);
            } else if (spellBook.GetComponent<Spell_Book>().tier == 3)
            {
                tier3.Add(spellBook);
            }
            else
            {
                tier4.Add(spellBook);
            }
        }
       
    }
    // Update is called once per frame
    void Update()
    {
         if (inside && Input.GetKeyDown(KeyCode.F))
        {
            
           
            if(shopCanvas.gameObject.activeInHierarchy)
            {
                shopCanvas.gameObject.SetActive(false);
            }
            else
            {
                shopCanvas.gameObject.SetActive(true);
            }
        }
    }
    public void SetSeletectedSpell(GameObject Spell)
    {
        selectedItem = Spell;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponent<PlayerController>().isLocalPlayer)
        {
            //shopCanvas.gameObject.SetActive(true);
            inside = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponent<PlayerController>().isLocalPlayer)
        {
            //shopCanvas.gameObject.SetActive(false);
            inside = false;
        }

    }
    public void GiveOutScrolls()
    {
        spellSlot1.SetStoredSpell(spellInventory[Random.Range(0, spellInventory.Count - 1)]);
        spellSlot2.SetStoredSpell(spellInventory[Random.Range(0, spellInventory.Count - 1)]);
        spellSlot3.SetStoredSpell(spellInventory[Random.Range(0, spellInventory.Count - 1)]);
        spellSlot4.SetStoredSpell(spellInventory[Random.Range(0, spellInventory.Count - 1)]);
    }
}

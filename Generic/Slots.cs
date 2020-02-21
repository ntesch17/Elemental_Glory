using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Items item;
    GameObject slot;
    string slotName;
    SpriteRenderer sprite;
    bool hasItem;
   // GameObject child;

    void Start()
    {
        slot = this.gameObject;
        slotName = this.name;
        sprite = slot.GetComponentInChildren<SpriteRenderer>();
        hasItem = false;
       
    }

    public bool FreeSlot()
    {
        return !hasItem;
    }
   
    public void setItem(Items item_m)
    {
        hasItem = true;
           item = item_m;
        this.name = item_m.itemName;
        
        sprite.sprite = item_m.icon;

       // print("W: " + GetComponent<RectTransform>().rect.width);
        //this.gameObject.transform.GetChild(0).localScale = new Vector3(17.5f,17.5f,1);
       // print("X: " + sprite.size.x);
        //sprite.flipX = true;
    }

    public Items TakeItem()
    {
        hasItem = false;
        var itemV = item;
        item = null;
        sprite.sprite = null;
        this.name = slotName;
        return itemV;
    }
    public Items GetItem()
    {
        return item;
    }
}

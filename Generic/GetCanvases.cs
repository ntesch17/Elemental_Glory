using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCanvases : MonoBehaviour
{
   public Canvas HPCanvas, OtherCanvas, PauseCanvas;
   public List<Slots> slots;
   public List<Slots> eqiupedSlots;
   public Slots basicSpellSlot;

    public List<GameObject> players;

   public Canvas DeepCopy(Canvas canvas)
    {
        Canvas dp = new Canvas();

        dp.GetComponentInChildren<LocalHpScale>().Player = null;
        dp.GetComponentInChildren<LocalManaScale>().Player = null;

        return dp;
    }
    public void Awake()
    {
        SetPlayer(players[0]);
    }

    public void SetPlayer(GameObject Player)
    {
        slots = new List<Slots>();
        eqiupedSlots = new List<Slots>();
        basicSpellSlot = new Slots();


        var hpCan = Instantiate<Canvas>(HPCanvas);
        hpCan.GetComponentInChildren<LocalHpScale>().Player = Player;
        hpCan.GetComponentInChildren<LocalManaScale>().Player = Player;

        var otherCan = Instantiate<Canvas>(OtherCanvas);
        otherCan.GetComponentInChildren<AlternateSpots>().player = Player.GetComponent<PlayerController>();

        var pauseCan = Instantiate<Canvas>(PauseCanvas);
        Player.GetComponent<PlayerController>().pauseCanvas = pauseCan;
        for (int i = 0; i < 19; i++)
        {
            print("First " + pauseCan.transform.GetChild(0).name);

            slots.Add(pauseCan.transform.GetChild(0).Find("Inventory Slot" + i).gameObject.GetComponentInChildren<SlotsClickManager>());
        }

        for (int i = 0; i < 5; i++)
        {
            print("Second");
            eqiupedSlots.Add(otherCan.transform.GetChild(0).Find("Hot Key Spells" + i).gameObject.GetComponentInChildren<SlotsClickManager>());
        }

        basicSpellSlot = otherCan.transform.GetChild(0).Find("Basic Spell").gameObject.GetComponent<SlotsClickManager>();

        Player.GetComponent<Inventory>().itemsInventory = slots;

        for (int i = 0; i < 5; i++)
        {
            Player.GetComponent<Inventory>().equipedSpells[i] = slots[i];
        }

        Player.GetComponent<Inventory>().basicSpellSlot = basicSpellSlot;

        

    }
}

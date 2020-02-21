using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetCanvases1 : NetworkBehaviour
{
   public Canvas HPCanvas, OtherCanvas, PauseCanvas;
   public List<Slots> slots;
   public List<Slots> eqiupedSlots;
   public Slots basicSpellSlot, ultimateSlot;

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
       // SetPlayer(players[0]);
    }

    public void SetPlayer(GameObject Player)
    {
        slots = new List<Slots>();
        eqiupedSlots = new List<Slots>();
       // basicSpellSlot = new Slots();

        
        var hpCan = Instantiate<Canvas>(HPCanvas);
        hpCan.GetComponentInChildren<LocalHpScale>().Player = Player;
        hpCan.GetComponentInChildren<LocalManaScale>().Player = Player;
        Player.GetComponent<PlayerController>().hpcan = hpCan;

        var otherCan = Instantiate<Canvas>(OtherCanvas);
        otherCan.GetComponentInChildren<AlternateSpots>().player = Player.GetComponent<PlayerController>();
        otherCan.worldCamera = Camera.main;
        Player.GetComponent<PlayerController>().other = otherCan;


        var pauseCan = Instantiate<Canvas>(PauseCanvas);
        pauseCan.worldCamera = Camera.main;
        Player.GetComponent<PlayerController>().pauseCanvas = pauseCan;

        for (int i = 0; i < 15; i++)
        {
           // print("First " + pauseCan.transform.GetChild(0).name);

            slots.Add(pauseCan.transform.GetChild(2).Find("Inventory Slot" + i).gameObject.GetComponentInChildren<SlotsClickManager>());
        }

        for (int i = 0; i < 5; i++)
        {
           // print("Second");
            eqiupedSlots.Add(otherCan.transform.GetChild(0).Find("Hot Key Spells" + i).gameObject.GetComponentInChildren<SlotsClickManager>());
        }

      //  basicSpellSlot = otherCan.transform.GetChild(0).Find("Basic Spell").gameObject.GetComponent<SlotsClickManager>();
        ultimateSlot = otherCan.transform.GetChild(0).Find("Ultimate Spell").gameObject.GetComponent<SlotsClickManager>();

        Player.GetComponent<Inventory>().itemsInventory = slots;

        for (int i = 0; i < 5; i++)
        {
            Player.GetComponent<Inventory>().equipedSpells[i] = eqiupedSlots[i];
        }

      //  Player.GetComponent<Inventory>().basicSpellSlot = basicSpellSlot;
        Player.GetComponent<Inventory>().equipedSpells[5] = ultimateSlot;

        Player.GetComponent<PlayerController>().hpcan.gameObject.SetActive(false);
        Player.GetComponent<PlayerController>().other.gameObject.SetActive(false);
    }
}

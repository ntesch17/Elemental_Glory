using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PresetPick : NetworkBehaviour
{
    //[SyncVar]
    public Canvas pickCanvas;
    public List<GameObject> FireSpells = new List<GameObject>();
    public List<GameObject> WaterSpells = new List<GameObject>();
    public List<GameObject> MixSpells = new List<GameObject>();
    public RuntimeAnimatorController waterAnim;
    public Sprite waterIdle1;
    public GameObject Player,torunyScript;
    public bool ready;
    public Text text;

    public void Start()
    {
        //torunyScript = GameObject.Find("TournyStuff");
        pickCanvas.gameObject.SetActive(false);
    }
    public void Update()
    {
        if (MixSpells.Count == 6&&!ready)
        {
            ready = true;
            if (Player.GetComponent<PlayerController>().ID == 1)
            {
                torunyScript.GetComponent<TournamentScript>().player1Ready = true;
                torunyScript.GetComponent<TournamentScript>().UpdateBool1();
                torunyScript.GetComponent<TournamentScript>().SendToArena(Player.GetComponent<PlayerController>());
            }
            else
            {
                torunyScript.GetComponent<TournamentScript>().player2Ready = true;
                torunyScript.GetComponent<TournamentScript>().UpdateBool2();
                torunyScript.GetComponent<TournamentScript>().SendToArena(Player.GetComponent<PlayerController>());
            }
            torunyScript.GetComponent<TournamentScript>().CmdReadyIncreased2();
            torunyScript.GetComponent<TournamentScript>().IncreaseReady();
            //torunyScript.GetComponent<TournamentScript>().UpdateBools();
            /*
            foreach (GameObject book in MixSpells)
            {
                Instantiate(book, Player.transform.position, new Quaternion(0, 0, 0, 0));
            }*/
            pickCanvas.gameObject.SetActive(false);
        }
    }
    public void GiveSpells()
    {
        foreach (GameObject book in MixSpells)
        {
            Instantiate(book, Player.transform.position, new Quaternion(0, 0, 0, 0));
        }
    }
    public void SetText()
    {
        text.text = "Pick " + (6 - MixSpells.Count) + " Spells";
    }
    public void HideUltimates(GameObject ultimateSpell)
    {
        ultimateSpell.SetActive(false);
    }
    public void AddToSpells(GameObject spellbook)
    {
        MixSpells.Add(spellbook);
    }
    public void HideSpellButton(GameObject spellButton)
    {
        spellButton.gameObject.SetActive(false);
    }
    public void OnFirePreset()
    {
        print("Picked Fire");
        foreach(GameObject book in FireSpells)
        {
            Instantiate(book, Player.transform.position, new Quaternion(0, 0, 0, 0));
        }
        //Drop Fire Books
        pickCanvas.gameObject.SetActive(false);
    }
    public void OnWaterPreset()
    {
        print("Picked Water");
        foreach (GameObject book in WaterSpells)
        {
            Instantiate(book, Player.transform.position, new Quaternion(0,0,0,0));
        }
        Player.gameObject.GetComponent<SpriteRenderer>().sprite = waterIdle1;
        Player.gameObject.GetComponent<Animator>().runtimeAnimatorController = waterAnim;
        //Drop Water Books
        pickCanvas.gameObject.SetActive(false);
    }
    public void PlaceHud(PlayerController player)
    {
        print("Started");
        Player = player.gameObject;
        pickCanvas.gameObject.SetActive(true);

    }
    public void ClientSaidReady()
    {
        GetComponent<IDCreation>().GetIDnum();
        //readys++;
        // CmdReadiedUp();
        pickCanvas.gameObject.SetActive(false);

    }
    [Command]
    public void CmdReadiedUp()
    {
        RpcReady();
        GetComponent<IDCreation>().GetIDnum();
    }
    [ClientRpc]
    public void RpcReady()
    {
        
        GetComponent<IDCreation>().GetIDnum();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.Networking;

public class TournamentScript : NetworkBehaviour
{

    // public PlayerController[] players;
    public Transform safe;//,round1a,round1b, round1c, round1d, round2a, round2b;
    public List<Arena> Arenas = new List<Arena>();
    public List<PlayerController> winners, losers, players;
    public bool round1, round2,player1Ready, player2Ready;
    int roundNumber = 1;
    public PlayerController thisPlayer;
    public static Transform safeArea;
    public GameObject IDmaker;

    //[SyncVar]
    public int readys;


    // private MatchInfoSnapshot match;

    // Start is called before the first frame update
    void Start()
    {
       IDmaker = GameObject.Find("Network Manager");
        safeArea = safe;
    }

    // Update is called once per frame
    void Update()
    {
        if(!round1&&false)//(player1Ready&&player2Ready)||readys>=2)
        checkPlayersSize();
    }
    public void addPlayer(PlayerController player)
    {
        players.Add(player);
        player.transform.position = safe.position;
       // checkPlayersSize();
       // player.GetComponent<CameraMode>().enabled = true;
    }
    public void IncreaseReady()
    {
        readys++;
        CmdReadyIncreased(readys);
    }
    [Command]
    public void CmdReadyIncreased2()
    {
        RpcReadyIncreased(readys);
    }

    [Command]
    private void CmdReadyIncreased(int ready)
    {
        //readys = ready;
        RpcReadyIncreased(ready);
    }
    [ClientRpc]
    private void RpcReadyIncreased(int ready)
    {
        readys = ready;
    }

    public void UpdateBool1()
    {
        CmdUpdateBool1(player1Ready);    
    }
    public void UpdateBool2()
    {
        CmdUpdateBool2(player2Ready);
    }
    [Command]
    public void CmdUpdateBool1(bool boolean)
    {
        player1Ready = boolean;
        RpcUpdateBool1(player1Ready);
    }
    [Command]
    public void CmdUpdateBool2(bool boolean)
    {
        player2Ready = boolean;
        RpcUpdateBool2(player2Ready);

    }
    [ClientRpc]
    public void RpcUpdateBool1(bool boolean)
    {
        player1Ready = boolean;
    }
    [ClientRpc]
    public void RpcUpdateBool2(bool boolean)
    {
        player2Ready = boolean;
    }

    private void checkPlayersSize()
    {
        if (players.Count == 2)
        {
            SendPlayersToRound1();
            round1 = true;
            //round1 = true;
            //thisPlayer.GetComponent<CameraMode>().enabled = true;

            //thisPlayer.GetComponent<CameraMode>().enabled = false;
        }
        FindLocalPlayer();
        //
    }

    private void FindLocalPlayer()
    {
        foreach(PlayerController player in players)
        {
            if (player.isLocalPlayer)
            {
                thisPlayer = player;
            }
                
        }
    }

    private void SendPlayersToRound1()
    {

       // players[0].transform.position = Arenas[0].position;
      //  players[1].transform.position = round1b.position;
        Arenas[0].AddPlayers(players[0], players[1]);
        IDmaker.GetComponent<PresetPick>().GiveSpells();
        //Arenas[1].AddPlayers(players[2], players[3]);


        //PlayerController[] players1 = { players[0], players[1] };//,players[2],players[3] };
        //players[0].gameObject.GetComponent<CameraMode>().SetCameraPositions(players1);
        //players[1].gameObject.GetComponent<CameraMode>().SetCameraPositions(players1);
       // players[2].gameObject.GetComponent<CameraMode>().SetCameraPositions(players1);
       // players[3].gameObject.GetComponent<CameraMode>().SetCameraPositions(players1);

        round1 = true;
        //GetComponent<PresetPick>().PlaceHud(thisPlayer);

    }
    public void SendToArena(PlayerController player1)
    {
        Arenas[0].AddPlayer(player1);
        IDmaker.GetComponent<PresetPick>().GiveSpells();
    }
    public void GoToSafeArea(PlayerController player)
    {
        player.gameObject.transform.position = safeArea.position;
    }
    public void WonRound(PlayerController player)
    {
        player.gameObject.transform.position = safeArea.position;
        winners.Add(player);
    }

    public void LoseRound(PlayerController player)
    {
        FindArenaOf(player).DecideLoser(player);
        /*
        player.gameObject.transform.position = safeArea.position;
        players.Remove(player);
        losers.Add(player);
        print("Added to losers");
        //Hide name and health
        player.gameObject.GetComponent<CameraMode>().enabled = true;
        GameObject[] players1 = { players[0].gameObject, players[1].gameObject };
        player.gameObject.GetComponent<CameraMode>().SetCameraPositions(players1);
        player.CmdSetHP(100);
        player.name += " (Dead)";
        player.enabled = false;*/
    }
    public static Transform GetSafeArea()
    {
        return safeArea;
    }
    public Arena FindArenaOf(PlayerController player)
    {
        foreach(Arena arena in Arenas)
        {
            if (arena.InArena.Contains(player)){
                return arena;
            }
        }
        print("Couldnt find arena");
        return null;
    }
}

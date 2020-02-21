using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class IDCreation : NetworkBehaviour
{
    [SyncVar]
    public int IDnum;

    public List<KeyValuePair<PlayerController,int>> PlayerList = new List<KeyValuePair<PlayerController, int>>();
    public int[] spellIDTEST = new int[3];
    public TournamentScript tourny;

    public void Start()
    {
        //tourny = GameObject.Find("TournyStuff").GetComponent<TournamentScript>();
    }
    public int GetIDnum()
    {
        IDnum++;
        int num = IDnum + 0;
        return num;
    }
    public void RegisterPlayer(PlayerController player)
    {
        PlayerList.Add(new KeyValuePair<PlayerController, int>(player,player.ID));
        tourny.addPlayer(player);
    }
    public PlayerController GetPlayer(int ID)
    {
        for (int i = 0; i <= PlayerList.Count - 1; i++)
        {
            if (PlayerList[i].Value == ID)
            {
                return PlayerList[i].Key;
            }
        }
        return null;
    }
}

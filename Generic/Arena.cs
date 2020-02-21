using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Arena : NetworkBehaviour
{
    public List<PlayerController> InArena;
    public bool started,ended;
    public PlayerController winner, loser;
    public Transform spawn1, spawn2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InArena.Count == 2&&!started)
            started = true;

        if (started&&!ended)
        {
            foreach (PlayerController player in InArena)
            {
                if (player.GetDead())
                {
                    DecideLoser(player);
                }
            }
        }
        
    }
    public void DecideLoser(PlayerController player)
    {
        loser = player;
        ended = true;
        CmdDecideLoser(loser.ID, ended);
    }
    [Command]
    public void CmdDecideLoser(int playerID,bool end)
    {
        var IDmaker = GameObject.Find("Network Manager");
        loser = IDmaker.GetComponent<IDCreation>().GetPlayer(playerID);
        ended = end;
        loser.gameObject.GetComponent<CameraMode>().dead = true;
    }
    public void AddPlayers(PlayerController player, PlayerController player2)
    {
        InArena.Add(player);
        InArena.Add(player2);
        player.transform.position = spawn1.transform.position;
        player2.transform.position = spawn2.transform.position;
    }
    public void AddPlayer(PlayerController player)
    {
        InArena.Add(player);
        //InArena.Add(player2);
        if(player.ID==1)
        player.transform.position = spawn1.transform.position;
        else
            player.transform.position = spawn2.transform.position;

        //player2.transform.position = spawn2.transform.position;
    }
}

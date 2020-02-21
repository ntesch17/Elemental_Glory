using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionObject : NetworkBehaviour

{
    GameObject health;
    GameObject sprite;

    public static List<GameObject> players = new List<GameObject>();

    public GameObject PlayerPrefab, Health;
    // Start is called before the first frame update
    void Start()
    {
        //check to see if this my own player PlayerConnectionObject
        if (hasAuthority == false)
        {
            //This object is not mine.
            return;
        }
        Debug.Log("PlayerConnectionObject::Start -- Spawning my own personal unit.");

        sprite = Instantiate(PlayerPrefab);
        players.Add(sprite);
        CmdSpawnPlayer(); //call the spawn player command
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAuthority == false)
        {
            //This object is not mine.
            return;
        }
        /*
        if (health.GetComponent<FollowPlayer2>().Player == null)
        {
            foreach (GameObject player in players)
            {
                health = Instantiate(Health);

                NetworkServer.Spawn(health);

                health.GetComponent<FollowPlayer2>().Player = player;
                health.GetComponentInChildren<ScaleBasedOnHp>().Player = player;
                health.GetComponentInChildren<ScaleBasedOnMana>().Player = player;

            }
        }*/
    }

    [Command]
    void CmdSpawnPlayer()
    {
        //RpcAttachHealth(/*players*/);
        NetworkServer.SpawnWithClientAuthority(sprite, connectionToClient);
        //spawn the object on the client 
    }


   [ClientRpc]
    public void RpcAttachHealth(/*List<GameObject> Players*/)
    {
        print("MEMEMEMEMEMMEMES");

        
        /*
        foreach (GameObject player in players)
        {
            health = Instantiate(Health);

            NetworkServer.Spawn(health);

            health.GetComponent<FollowPlayer2>().Player = player;
            health.GetComponentInChildren<ScaleBasedOnHp>().Player = player;
            health.GetComponentInChildren<ScaleBasedOnMana>().Player = player;

        }*/
    }
}
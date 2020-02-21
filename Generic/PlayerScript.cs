using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerScript : NetworkBehaviour
{
    public GameObject playerUnitPrefab;
    GameObject myPlayerUnit;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        print("Player Object Start -- spawning my own player unit");
       
        CmdSpawnMyUnit();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        

    }
    [Command]
    void CmdSpawnMyUnit()
    {
       myPlayerUnit = Instantiate(playerUnitPrefab);

        

       // go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
        //or
        NetworkServer.SpawnWithClientAuthority(myPlayerUnit, connectionToClient);

       // NetworkServer.Spawn(go);
    }
    /*
    [Command]
    void CmdMoveUnitUp()
    {
        if (myPlayerUnit == null)
        {
            return;
        }
        myPlayerUnit.transform.Translate(0,1,0);
    }
    */
}

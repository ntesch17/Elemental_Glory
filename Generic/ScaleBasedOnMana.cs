using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ScaleBasedOnMana : NetworkBehaviour
{
    [SyncVar]
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            var maxMana = Player.GetComponent<PlayerController>().GetMaxMana();
            var mana = Player.GetComponent<PlayerController>().GetMana();
            var scale = mana / maxMana;

            this.transform.localScale = new Vector3(scale, this.transform.localScale.y, this.transform.localScale.z);
        }
        else
        {
            Player = GetComponentInParent<FollowObjectWithDif>().followedObject;
        }



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaScale : MonoBehaviour
{
    public GameObject Player;
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
     


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateSpots : MonoBehaviour
{
    public PlayerController player;
    public GameObject unpausedSpot,pausedSpot;
   
    // Update is called once per frame
    void Update()
    {
        if (player.GetPaused())
        {
            this.transform.position = pausedSpot.transform.position;
        }
        else
        {
            this.transform.position = unpausedSpot.transform.position;
        }
    }
}

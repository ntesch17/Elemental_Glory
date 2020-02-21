using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : MonoBehaviour
{
    public PlayerController caster;
    public Modifier earthquakeDmgMod,earthquakeSlowMod;
    public List<PlayerController> players = new List<PlayerController>();


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>() != this.caster)
        {
            print("Player entered: " + other.gameObject.GetComponent<PlayerController>().Name);

            if (!players.Contains(other.gameObject.GetComponent<PlayerController>()))
                players.Add(other.gameObject.GetComponent<PlayerController>());

        }
    }public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>() != this.caster)
        {
            print("Player entered: " + other.gameObject.GetComponent<PlayerController>().Name);

            if (!players.Contains(other.gameObject.GetComponent<PlayerController>()))
                players.Add(other.gameObject.GetComponent<PlayerController>());

        }
    }
    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>() != this.caster)
        {

            print("Player exited: " + other.gameObject.GetComponent<PlayerController>().Name);

            players.Remove(other.gameObject.GetComponent<PlayerController>());
        }
    }

    public void FixedUpdate()
    {
        foreach (PlayerController player in players)
        {
            player.AddModifier(earthquakeDmgMod);

            player.AddModifier(earthquakeSlowMod);

            //collision.GetComponent<PlayerController>().AddModifier(new BurnModifier());

        }
    }
    /*
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerController>() != this.caster)
        {
            print("Player entered: " + other.GetComponent<PlayerController>().Name);

            if (!players.Contains(other.GetComponent<PlayerController>()))
                players.Add(other.GetComponent<PlayerController>());
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerController>() != this.caster)
        {

            print("Player exited: " + other.GetComponent<PlayerController>().Name);

            players.Remove(other.GetComponent<PlayerController>());
        }
    }*/

    public void DestroyEarthquake()
    {
        Destroy(this.GetComponent<Earthquake>());
    }
}

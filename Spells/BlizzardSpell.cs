using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BlizzardSpell : Spell
{
    public List<PlayerController> players = new List<PlayerController>();
    BlizzardDpsModifier blizzardMod;
   

    public override void OnAwake()
    {
        base.OnAwake();
        this.GetComponent<FollowObjectWithDif>().followedObject = caster.gameObject;
    }
    public void Awake()
    {
        //mod[0] = new ChilledModifier();
        mod[0].creator = this.caster;
       // mod[1] = new BlizzardDpsModifier();
        mod[1].creator = this.caster;
    }
    public void FixedUpdate()
    {
        foreach (PlayerController player in players)
        {
            /*
            player.AddModifier(mod[1]);
            */
            player.AddModifier(mod[0]);

            CmdDamagePlayer(player.ID,GetDamage() * Time.fixedDeltaTime);
            //collision.GetComponent<PlayerController>().AddModifier(new BurnModifier());
           
        }
    }
    
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
    }
}

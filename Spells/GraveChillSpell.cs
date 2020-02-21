using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveChillSpell : Spell
{
    public List<PlayerController> players = new List<PlayerController>();

    ParticleSystem myParticleSystem;
    //ParticleSystem.EmissionModule emissionModule;

    public override void OnAwake()
    {
        base.OnAwake();
        Physics2D.IgnoreCollision(this.GetComponentInChildren<Collider2D>(), caster.GetComponent<Collider2D>());
        myParticleSystem = GetComponentInChildren<ParticleSystem>();
        // var emissionModule = myParticleSystem.main;
        //Invoke("ParticleStuff", .5f);
        //myParticleSystem.Stop();
        //myParticleSystem.Play();

        if(this.GetLevel()>=2)
        GetComponent<CircleCollider2D>().radius = 1.6f;

    }
    public void ParticleStuff()
    {
        myParticleSystem.Stop();
    }
    public void FixedUpdate()
    {
        foreach (PlayerController player in players)
        {
            //player.AddModifier(mod[1]);

            player.AddModifier(mod[this.GetLevel()-1]);
            CmdDamagePlayer(player.ID, (damage[GetLevel()-1]/2) * Time.fixedDeltaTime);
            //collision.GetComponent<PlayerController>().AddModifier(new BurnModifier());

        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerController>() != this.caster)
        {
            if (other.GetComponent<PlayerController>().ModContains("Soaked"))
                print("HES SOAKED");


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

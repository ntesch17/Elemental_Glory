    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBombSpell : Spell
{
    public List<PlayerController> players = new List<PlayerController>();
    public float radius,power;
    Rigidbody2D rb2d;

    public void Awake()
    {
        element = Spell.FIRE_ELEMENT;
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(!players.Contains(other.GetComponent<PlayerController>()))
            players.Add(other.GetComponent<PlayerController>());
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            players.Remove(other.GetComponent<PlayerController>());
        }
    }

    public override void OnDestroy()
    {
        foreach(PlayerController player in players){
        ExplosionForce2D.AddExplosionForce(player.GetComponent<Rigidbody2D>(), power,this.transform.position,radius);
            player.Damage(GetDamage());
            //player.AddModifier(new BurnModifier());
            print(player.name + " was hit");
        }
        base.OnDestroy();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStormSpawn : Spell
{
    public List<PlayerController> players = new List<PlayerController>();
    public float radius, power;
    Rigidbody2D rb2d;

    public void Awake()
    {
        element = Spell.FIRE_ELEMENT;
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerController>() != caster.GetComponent<PlayerController>())
        {
            if (!players.Contains(other.GetComponent<PlayerController>()))
                players.Add(other.GetComponent<PlayerController>());
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerController>() != caster.GetComponent<PlayerController>())
        {
            players.Remove(other.GetComponent<PlayerController>());
        }
    }

    public override void OnDestroy()
    {
        /*
        foreach (PlayerController player in players)
        {
            ExplosionForce2D.AddExplosionForce(player.GetComponent<Rigidbody2D>(), power, this.transform.position, radius);
            player.Damage(GetDamage());
            //player.AddModifier(new BurnModifier());
            print(player.name + " was hit");
        }
        */
        base.OnDestroy();
    }
    public override void OnAwake()
    {
        level = 1;
        print(this.getName() + " Level : " + this.GetLevel());
        print(spellName + " level: " + level);
        if (mod[0] != null)
            mod[0].creator = this.caster;
        if (mod[1] != null)
            mod[1].creator = this.caster;
        if (mod[2] != null)
            mod[2].creator = this.caster;

        Destroy(this.gameObject, duration[level]);
    }
}

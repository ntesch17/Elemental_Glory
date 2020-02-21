using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSlashSpell : Spell
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        // print("Collidied with " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerController>() != caster)
        {
            OnContact(collision.gameObject.GetComponent<PlayerController>());
            Destroy(this);
            Destroy(this.GetComponent<Collider2D>());
        }
        else if (collision.gameObject.tag == "Spell" && collision.gameObject.GetComponent<Spell>().caster != caster)
        {
            OnContact(collision.gameObject.GetComponent<RockWall>());
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }

        //Destroy(this.gameObject);

    }
}

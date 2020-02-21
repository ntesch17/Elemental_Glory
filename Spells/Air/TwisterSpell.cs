using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwisterSpell : Spell
{
    public List<PlayerController> players = new List<PlayerController>();
    private Vector2 velocity;

    public override void OnAwake()
    {

        base.OnAwake();
        if (caster.GetComponent<Movement>().facingRight)
        {
            GetComponent<Rigidbody2D>().velocity = (Vector2.right * speed/2.5f);
        }else
        {
            GetComponent<Rigidbody2D>().velocity = (Vector2.left * speed/2.5f);
        }
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), caster.GetComponent<Collider2D>());

        mod[0].creator = this.caster;
    }
    public void startMovement()
    {
        if (caster.GetComponent<Movement>().facingRight)
        {
            GetComponent<Rigidbody2D>().velocity = (Vector2.right * speed);
            velocity = (Vector2.right * speed);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = (Vector2.left * speed);
            velocity = (Vector2.left * speed);
        }
        //velocity = GetComponent<Rigidbody2D>().velocity;
    }

    public void FixedUpdate()
    {
        if (players.Count != 0)
        {
            GetComponent<Rigidbody2D>().velocity = velocity/5;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = velocity;
        }

        foreach (PlayerController player in players)
        {

            //player.AddModifier(mod[0]);
            CmdDamagePlayer(player.ID, mod[0].amount*Time.fixedDeltaTime);
            //collision.GetComponent<PlayerController>().AddModifier(new BurnModifier());

        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"&&other.GetComponent<PlayerController>()!=caster.GetComponent<PlayerController>())
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
}

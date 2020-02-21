using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTornadoSpell : Spell
{
    public List<PlayerController> players = new List<PlayerController>();
    private Vector2 velocity;

    public override void OnAwake()
    {

        base.OnAwake();
        if (caster.GetComponent<Movement>().facingRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Vector2.right.x * speed / 2, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Vector2.left.x * speed / 2, GetComponent<Rigidbody2D>().velocity.y);
        }
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), caster.GetComponent<Collider2D>());

        mod[0].creator = this.caster;
        mod[1].creator = this.caster;
    }
    public void startMovement()
    {
        if (caster.GetComponent<Movement>().facingRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Vector2.right.x * speed, GetComponent<Rigidbody2D>().velocity.y);
            velocity = (Vector2.right * speed);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Vector2.left.x * speed, GetComponent<Rigidbody2D>().velocity.y);
            velocity = (Vector2.left * speed);
        }
        //velocity = GetComponent<Rigidbody2D>().velocity;
    }

    public void FixedUpdate()
    {
        if (players.Count != 0)
        {
            GetComponent<Rigidbody2D>().velocity = velocity / 4;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = velocity;
        }

        foreach (PlayerController player in players)
        {

            //player.AddModifier(mod[0]);
            CmdDamagePlayer(player.ID, mod[0].amount * Time.fixedDeltaTime);
            //collision.GetComponent<PlayerController>().AddModifier(new BurnModifier());

        }
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
}

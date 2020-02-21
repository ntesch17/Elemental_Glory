using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShard : Spell
{
    public GameObject fallingShard;
    public override void OnAwake()
    {
        base.OnAwake();
        if (this.GetLevel() >= 2)
        {
            this.transform.localScale /= 2;
        }
        
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (this.GetLevel() == 3)
        {
        var yAxis = collision.transform.position.y;
        GameObject fShard = Instantiate(fallingShard,collision.transform.position, new Quaternion(0f,0f,0f,0f));
            fShard.layer = 14;
        fShard.transform.position = new Vector3(collision.transform.position.x,yAxis +6);
            fShard.GetComponent<Spell>().caster = this.caster;
            fShard.GetComponent<Spell>().setLevel(this.GetLevel());
            Physics2D.IgnoreCollision(fShard.GetComponent<Collider2D>(), caster.GetComponent<Collider2D>());
            var rb2d = fShard.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 6;
        fShard.transform.rotation = Quaternion.Euler(0f,0f,-90f);

        }
        
    }
}

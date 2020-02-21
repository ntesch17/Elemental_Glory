using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCloudSpell : Spell
{
    bool following = false;
    PlayerController followingPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>()!=caster&&collision.tag == "Player"&&!following)
        {
            this.gameObject.AddComponent<FollowObjectWithDif>();
            this.gameObject.GetComponent<FollowObjectWithDif>().followedObject = collision.gameObject;
            followingPlayer = collision.gameObject.GetComponent<PlayerController>();
            this.gameObject.GetComponent<FollowObjectWithDif>().x = -.2399998f;
            this.gameObject.GetComponent<FollowObjectWithDif>().y = 2.53f;
            following = true;
        }
    }
    public void FixedUpdate()
    {
        if (following)
            followingPlayer.AddModifier(mod[0]);
    }
    public override void OnAwake()
    {
        base.OnAwake();

        if (this.GetLevel() >= 2)
        {
            Invoke("GiveChill", this.duration[1] - .25f);
            if (followingPlayer != this.caster)
            {
                followingPlayer.CmdDamamge(20);
            }
        }
            
    }
    public void GiveChill()
    {
        if (following)
        {
            followingPlayer.AddModifier(mod[2]);
        }
    }
}

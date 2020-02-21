using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthWallSpell : Spell
{
    public bool created = false;
    //public GameObject EarthWallHere;
    public override void OnAwake()
    {
        //mod[0] = new EarthWallModifier();
        //mod[1] = new EarthWallModifier();
        mod[1].creator = caster;
        mod[2].creator = caster;

       
        if (!created&& caster.GetSpellLevel(Spell.EARTH_WALL) ==3)
        {

            GameObject wall = Instantiate(this.gameObject, new Vector3(this.transform.position.x + 5, this.transform.position.y), new Quaternion(0, 0, 0, 0));
            wall.GetComponent<EarthWallSpell>().setCaster(caster);
            wall.GetComponent<EarthWallSpell>().created = true;
            wall.GetComponent<EarthWallSpell>().spellName = Spell.EARTH_WALL;
            wall.GetComponent<EarthWallSpell>().OnAwake();
        }
        base.OnAwake();
    }

    public override void OnContact(PlayerController playerHit)
    {
        setLevel(caster.GetSpellLevel(spellName));

        if (hasModifier[GetLevel() - 1])
            playerHit.AddModifier(GetModifier());
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerController>() != caster)
        {
            OnContact(collision.gameObject.GetComponent<PlayerController>());
            
        }
    }public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerController>() != caster)
        {
            OnContact(collision.gameObject.GetComponent<PlayerController>());
            
        }
    }

}

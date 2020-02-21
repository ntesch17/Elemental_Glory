using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeSpell : Spell
{
    public List<Collider2D> platforms = new List<Collider2D>();
    public Modifier[] secondMod = new Modifier[3];

    public override void OnAwake()
    {
        base.OnAwake();
        if (this.GetLevel() >= 3)
        {
            this.GetComponent<CircleCollider2D>().radius = 8;
        }
        this.GetComponent<FollowObjectWithDif>().followedObject = caster.gameObject;
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        foreach(Collider2D plat in platforms)
        {
            plat.GetComponent<Earthquake>().DestroyEarthquake();
        }
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
        /*
        foreach (Collider2D plat in platforms)
        { 
            //collision.GetComponent<PlayerController>().AddModifier(new BurnModifier());
        }*/
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platforms")
        {
            print("Platform entered: " + other.name);

            
            var eq = other.GetComponent<Earthquake>();
            if (eq == null)
            {
                other.gameObject.AddComponent<Earthquake>();
                var eqm = other.GetComponent<Earthquake>();
                eqm.caster = this.caster;
                eqm.earthquakeDmgMod = this.mod[this.GetLevel() - 1];
                eqm.earthquakeSlowMod = this.secondMod[this.GetLevel() - 1];

                if (!platforms.Contains(other.GetComponent<Collider2D>()))
                    platforms.Add(other.GetComponent<Collider2D>());
            }
        }
    }public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Platforms")
        {
            print("Platform entered: " + other.name);

           
            var eq = other.GetComponent<Earthquake>();
            if (eq == null)
            {
                other.gameObject.AddComponent<Earthquake>();
                var eqm = other.GetComponent<Earthquake>();
                eqm.caster = this.caster;
                eqm.earthquakeDmgMod = this.mod[this.GetLevel() - 1];
                eqm.earthquakeSlowMod = this.secondMod[this.GetLevel() - 1];

                if (!platforms.Contains(other.GetComponent<Collider2D>()))
                    platforms.Add(other.GetComponent<Collider2D>());
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Platforms")
        {
            print("Platform exited: " + other.name);


            var eq = other.GetComponent<Earthquake>();
            if (eq != null)
            {
                eq.DestroyEarthquake();
            }
            platforms.Remove(other.GetComponent<Collider2D>());
        }
    }
}

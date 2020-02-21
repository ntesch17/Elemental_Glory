using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoSpell : Spell
{
    public GameObject spawnee;
    public float spawnFrequency;

    public override void OnAwake()
    {
        base.OnAwake();
        print("Volcano Level : " + this.GetLevel());
        //OnAwake();
        InvokeRepeating("SpawnMeteor", .01f, spawnFrequency);
        if (this.GetLevel() >= 2)
        {
            print("IM IN BOIS");
            InvokeRepeating("SpawnMeteor2", .01f, spawnFrequency);
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {

    }
    void SpawnMeteor()
    {
        print("spawning meteor");
        GameObject meteorOrb = Instantiate(spawnee, new Vector3(this.transform.position.x + Random.Range(-.1f, .1f), transform.position.y), new Quaternion(0, 0, 0, 0));
        var rb2d = meteorOrb.GetComponent<Rigidbody2D>();
        meteorOrb.GetComponent<Spell>().caster = this.caster;
        meteorOrb.GetComponent<Spell>().setLevel(this.GetLevel());
        meteorOrb.transform.rotation = Quaternion.Euler(0, 0, Random.Range(30-90, 150-90));
        meteorOrb.layer = 14;
        Vector2 vector = new Vector2(Mathf.Cos(meteorOrb.transform.rotation.z), Mathf.Sin(meteorOrb.transform.rotation.z));
        vector.Normalize();
        Physics2D.IgnoreCollision(meteorOrb.GetComponent<Collider2D>(), caster.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(meteorOrb.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        rb2d.velocity = meteorOrb.transform.up * this.speed;
        Destroy(meteorOrb.gameObject, meteorOrb.GetComponent<Spell>().duration[GetLevel()-1]);

        //SpawnMeteor2();
    }
    void SpawnMeteor2()
    {
        print("spawning meteor2");
        GameObject meteorOrb = Instantiate(spawnee, new Vector3(this.transform.position.x + Random.Range(-.1f, .1f), transform.position.y), new Quaternion(0, 0, 0, 0));
        var rb2d = meteorOrb.GetComponent<Rigidbody2D>();
        meteorOrb.GetComponent<Spell>().caster = this.caster;
        meteorOrb.GetComponent<Spell>().setLevel(this.GetLevel());
        meteorOrb.transform.rotation = Quaternion.Euler(0, 0, Random.Range(30 - 90, 150 - 90));
        meteorOrb.layer = 14;
        Vector2 vector = new Vector2(Mathf.Cos(meteorOrb.transform.rotation.z), Mathf.Sin(meteorOrb.transform.rotation.z));
        vector.Normalize();
        Physics2D.IgnoreCollision(meteorOrb.GetComponent<Collider2D>(), caster.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(meteorOrb.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        rb2d.velocity = meteorOrb.transform.up * this.speed;
        Destroy(meteorOrb.gameObject, meteorOrb.GetComponent<Spell>().duration[GetLevel()-1]);
    }
}

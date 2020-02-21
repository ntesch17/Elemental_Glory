using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : Spell
{
    bool hitSomeone = false;
    public GameObject shard;
    private void Awake()
    {
        setName(Spell.WATER_BALL);
        applyGravity = true;
        projectile = true;
        baseImpactDmg = new float[]{ 5,5,5 };
        damage = new float[]{ 5,5,5 };
        impactDmg = new float[] { 5, 5, 5 };
        baseDamage = new float[] { 5, 5, 5 };
        manaCost = new float[] { 3, 3, 3 };
        element = Spell.WATER_ELEMENT;
        //duration = new float[]{ 3,3,3 };
        //level = 1;
        //mod = new Modifier[]{null,null,new SoakedModifier()};
        mod[2].creator = caster;
        speed = 5;
        Invoke("SpawnShards",duration[2]-.1f);
        
      //  print("MOD: " + mod[2].modName);
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        hitSomeone = true;
        base.OnCollisionEnter2D(collision);
    }
    public void SpawnShards()
    {
        if (!hitSomeone & this.GetLevel()==3)
        {
            var size = this.GetComponent<Collider2D>().bounds.size;
            for (int i = 0; i <= 2; i++)
            {
                //print("VelocityX: " + this.gameObject.GetComponent<Rigidbody2D>().velocity.x);
                var shardSpawned = Instantiate(shard, new Vector3(Random.Range(this.transform.position.x-size.x,this.transform.position.x+size.x), Random.Range(this.transform.position.y - size.y, this.transform.position.y + size.y)), new Quaternion(0, 0, 0, 0));
                var rb2d = shardSpawned.GetComponent<Rigidbody2D>();
                shardSpawned.GetComponent<Spell>().caster = this.caster;
                shardSpawned.GetComponent<Spell>().setLevel(this.GetLevel());
                shardSpawned.transform.rotation = this.transform.rotation;
                Physics2D.IgnoreCollision(shardSpawned.GetComponent<Collider2D>(), caster.GetComponent<Collider2D>());
                rb2d.velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
            }
        }
    }
}

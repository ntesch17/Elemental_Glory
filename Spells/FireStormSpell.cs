using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FireStormSpell : Spell
{
    public GameObject meteor,peak;
    public void Awake()
    {
        //OnAwake();
        InvokeRepeating("SpawnMeteor", .01f, .3f);
    }
   
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    void SpawnMeteor()
    {
        CmdSpawnMeteor();
    }
    [Command]
    void CmdSpawnMeteor()
    {
        print("spawning meteor");
        GameObject meteorOrb = Instantiate(meteor, new Vector3(this.transform.position.x + Random.Range(-10, 10), peak.transform.position.y), new Quaternion(0, 0, 0, 0));
        NetworkServer.Spawn(meteorOrb);
       
        var rb2d = meteorOrb.GetComponent<Rigidbody2D>();
        meteorOrb.GetComponent<Spell>().caster = this.caster;
        meteorOrb.GetComponent<Spell>().casterID = casterID;
        meteorOrb.GetComponent<Spell>().setLevel(1);
        meteorOrb.GetComponent<Spell>().Update();
        meteorOrb.GetComponent<Spell>().OnAwake();
        CmdAwake(meteorOrb);

        //RpcAwake(meteorOrb);

        meteorOrb.transform.rotation = Quaternion.Euler(0, 0, -180);
        meteorOrb.layer = 14;
        Vector2 vector = new Vector2(Mathf.Cos(-150), Mathf.Sin(-150));
        vector.Normalize();
        CmdFixPls(meteorOrb);
        //FixPls(meteorOrb);
        Physics2D.IgnoreCollision(meteorOrb.GetComponent<Collider2D>(), caster.GetComponent<Collider2D>());
        rb2d.velocity = meteorOrb.transform.up * this.speed;
        Destroy(meteorOrb.gameObject, meteorOrb.GetComponent<Spell>().duration[GetLevel()]);
    }

    [Command]
    public void CmdFixPls(GameObject obj1)//,GameObject obj2)
    {
        var IDmaker = GameObject.Find("Network Manager");
        Physics2D.IgnoreCollision(obj1.GetComponent<Collider2D>(), obj1.GetComponent<Spell>().GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(obj1.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        RpcFixPls(obj1);

    }

    [ClientRpc]
    public void RpcFixPls(GameObject obj1)//,GameObject obj2)
    {
        var IDmaker = GameObject.Find("Network Manager");
        Physics2D.IgnoreCollision(obj1.GetComponent<Collider2D>(), obj1.GetComponent<Spell>().GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(obj1.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        FixPls(obj1);

    }
    public void FixPls(GameObject obj1)//,GameObject obj2)
    {
        var IDmaker = GameObject.Find("Network Manager");


        Physics2D.IgnoreCollision(obj1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      
    }

    [Command]
    public void CmdAwake(GameObject orb)
    {
       

        // orb.GetComponent<Spell>().level = spell.level;
        orb.GetComponent<Spell>().OnAwake();

    }[ClientRpc]
    public void RpcAwake(GameObject orb)
    {
       

        // orb.GetComponent<Spell>().level = spell.level;
        orb.GetComponent<Spell>().OnAwake();

    }

}

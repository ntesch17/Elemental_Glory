using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFireBallScriptStuff : MonoBehaviour
{
    public bool moving = true,diving,shooting,death,facingRight = true;
    public GameObject leftMost, rightMight,fireball, peak;
    Rigidbody2D rb2d;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            rb2d.velocity = new Vector2(3 * transform.localScale.x, 0);
        }
        if(!moving)
        {
            rb2d.velocity = new Vector2(0, 0);
            anim.SetTrigger("endFlight");
            //Commence Dive
           // diving = true;
        }

        if(leftMost.transform.position.x > transform.position.x || rightMight.transform.position.x < transform.position.x)
        {
            Flip();
            transform.position = new Vector2(transform.position.x + .2f * transform.localScale.x, transform.position.y);
        }
        
    }
    private void LateUpdate()
    {
        
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void ShootUp()
    {
        var fireBoi = Instantiate(fireball,transform.position,new Quaternion(0,0,0,0));
            fireBoi.transform.rotation = Quaternion.Euler(0, 0, -90);
        var rb2d2 = fireBoi.GetComponent<Rigidbody2D>();
        rb2d.velocity = rb2d2.transform.up * 10;
        InvokeRepeating("SpawnMeteor", .01f, .2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            moving = false;
        }
    }

    void SpawnMeteor()
    {
        print("spawning meteor");
        GameObject meteorOrb = Instantiate(fireball, new Vector3(this.transform.position.x + Random.Range(-10, 10), peak.transform.position.y), new Quaternion(0, 0, 0, 0));

       

        //RpcAwake(meteorOrb);

        meteorOrb.transform.rotation = Quaternion.Euler(0, 0, -90);
        meteorOrb.layer = 14;
       // meteorOrb.GetComponent<Collider2D>().enabled = true;
        //FixPls(meteorOrb);
        var rb2d2 = meteorOrb.GetComponent<Rigidbody2D>();
        //Physics2D.IgnoreCollision(meteorOrb.GetComponent<Collider2D>(), caster.GetComponent<Collider2D>());
        rb2d2.velocity = meteorOrb.transform.right * 20;
       // Destroy(meteorOrb.gameObject, meteorOrb.GetComponent<Spell>().duration[GetLevel()]);
    }
}

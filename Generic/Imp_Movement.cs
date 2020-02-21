using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp_Movement : MonoBehaviour
{
    bool facingRight = true;
    Rigidbody2D rb2d;
    Animator anim;
    public bool waiting;
    public GameObject fireball;
    public float speed;
    public GameObject player;
    public GameObject projectile;
    private void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }


    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag != "Player")
        {

            Flip();

        }

    }
    private void attack()
    {
       // float dist = Vector3.Distance(player.position, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            anim.SetTrigger("attack");
            Instantiate (fireball, new Vector3( 2.0f, 1.0f, 0), Quaternion.identity);
            fireball.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1000000);
            projectile.GetComponent<ShootFireBall>().target = player;
            collision.GetComponent<PlayerController>().CmdDamamge(10);
            print("youve been hit");



        }
        if (collision.tag != "Player")
        {

            anim.SetTrigger("go_idle");




        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {

            rb2d.velocity = new Vector2(3 * transform.localScale.x, rb2d.velocity.y);

        }

        //rb2d.velocity = new Vector2(3 * transform.localScale.x, rb2d.velocity.y);

    }

    public void Whenyousayrun()
    {

        waiting = false;
        Invoke("GoIdle", 5);



    }
    void GoIdle()
    {

        anim.SetTrigger("go_idle");
        waiting = false;
    }
}

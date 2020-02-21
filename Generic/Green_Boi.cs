using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_Boi : MonoBehaviour
{
    bool facingRight = true;
    Rigidbody2D rb2d;
    Animator anim;
    public bool waiting;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            anim.SetTrigger("attack");
            collision.GetComponent<PlayerController>().CmdDamamge(10);
            print("youve been hit");

        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void GoIdle()
    {

        anim.SetTrigger("go_idle");
        waiting = true;

    }

    void Shoot()
    {

        var proj = Instantiate(projectile, new Vector3(this.transform.position.x + 0.02092171f, this.transform.position.y + -0.02274287f), new Quaternion(0, 0, 0, 0));
        proj.GetComponent<missle_speed>().x = 10 * transform.localScale.x;
        if (!facingRight)
        {

            Vector3 theScale = proj.transform.localScale;
            theScale.x *= -1;
            proj.transform.localScale = theScale;

        }


    }




    // Update is called once per frame
    void Update()
    {
        if (waiting == false)
        {

            rb2d.velocity = new Vector2(3 * transform.localScale.x, rb2d.velocity.y);

        }
        else
        {

            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

        }

        rb2d.velocity = new Vector2(3 * transform.localScale.x, rb2d.velocity.y);

    }

    public void Whenyousayrun()
    {

        waiting = true;
        Invoke("GoIdle", 5);


    }
}

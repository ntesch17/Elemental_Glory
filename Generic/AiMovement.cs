using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public float distance;
    public float attackTimer = 2.0f;
    public bool movingRight = true;
    public bool canShoot = true;
    public Transform groundDetection;
    public GameObject fireBall;
    public GameObject player;
    public GameObject imp;
    private Transform target;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "fireBall")
        {
            Destroy(fireBall);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false) {
            if (movingRight == true)
            {
               
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        
        if (player!=null)
        {
            float dist = Vector2.Distance(player.transform.position, transform.position);
            print(dist);
            if (dist < 6)
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0)
                { 
                GameObject fb = Instantiate(fireBall, this.transform.position, new Quaternion(0, 0, 0, 0));
                   attackTimer = 2f;
                    anim.SetTrigger("isAttacking");
                   Destroy(fb, 4.0f);
                   float step = speed * Time.deltaTime; // calculate distance to move
                    //var diff = this.transform.position - 
                    //fb.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1000000);
                    fb.GetComponent<ShootFireBall>().target = player;
                    fb.GetComponent<ShootFireBall>().step = step;
             


                }
            }
            print("Distance to other: " + dist);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHound_Ai : MonoBehaviour
{
    public float speed;
    public float distance;
    float platformX = 9.27f;
    float platformY = -3.46f;
    public float distance_Floor;
    public bool movingRight = true;
    public bool isJumping = true;
    public Transform groundDetection;
    public Transform platformDetection;
    public Transform platformJumpDetection;
    Animator anim;
    public GameObject player;
    private Vector2 target;
    private Vector2 position;
   // float hasJumped = Animator.StringToHash("jump_Hellhound");
    int hasJumped = Animator.StringToHash("Base Layer.jump_Hellhound");
    //float isRunning = Animator.StringToHash("Base Layer.Run");
    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);    
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        RaycastHit2D platformInfo = Physics2D.Raycast(platformDetection.position, Vector2.up, distance);
        RaycastHit2D platformJumpInfo = Physics2D.Raycast(platformJumpDetection.position, Vector2.up, distance);
        //Will track the floor until the end and enemy Ai will run back and forth.
        //float distance_Floor = Vector2.Distance(floor.transform.position, transform.position); ;
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
               transform.eulerAngles = new Vector3(0, 0, 0);
               movingRight = true;
            }
          
        }

        //Tracks the distance from the player.
        if (player != null)
        {
            float dist = Vector2.Distance(player.transform.position, transform.position);
            print(dist);
            if (dist > 6 && dist < 15)
                 {  
                     //InvokeRepeating("hasThrowm" + waitTime);
                      //   Destroy(boulder, 4.0f);
                         float step = speed * Time.deltaTime; // calculate distance to move
                                                              //var diff = this.transform.position - 
                                                              //fb.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1000000);
                                                              //    projectile.GetComponent<ShootFireBall>().target = player;
                                                              //   projectile.GetComponent<ShootFireBall>().step = step;

                //Will make the AI jump between the floor and floor(1)
                if (groundInfo.collider == platformInfo.collider)
                {
                    transform.position = new Vector2(3.0f, -3.46f);
                    anim.SetTrigger("hasJumped");
                }
                if (groundInfo.collider == platformJumpInfo.collider)
                {
                    anim.SetTrigger("hasJumped");
                    transform.position = new Vector2(-12.81f, -3.46f);
                }
                //should make the AI jump between floor(1) and floor.

            }
        }
        }

    }
    


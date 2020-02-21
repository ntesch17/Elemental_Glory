using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JumpLogic : NetworkBehaviour {
    private Rigidbody2D rb2d;
   // public float jumpForce;
    Quaternion rotation;
    public float jumpCheck;
    public float jumpCheck2;
    public bool flight;
    Animator anim;
    public float speed = 10;
    public float jumpSpeed = 100;
    public bool otherGround;
    [SerializeField][ReadOnly] private bool onGround = false;
    private bool onGround2 = false;
    private float gravityScale;
    //private float jump = 1;
    // Use this for initialization
    private void Awake()
    {
        rotation = transform.rotation;
    }
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gravityScale = GetComponent<Rigidbody2D>().gravityScale;
    }
	
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }

        jumpCheck = rb2d.velocity.y;
       // Debug.Log(onGround);
        anim.SetBool("grounded",onGround);
        /*
        if((jumpCheck2 == jumpCheck||Mathf.Abs(jumpCheck2 - jumpCheck)<=.001f))// &&(rb2d.velocity.y==0||rb2d.velocity.y<=.001f))
        {
           
            onGround = true;
           // print("LEL" + onGround);
        }
        else
        {
            onGround = false;
        }*/

        if (!flight)
        {
            if ((Input.GetKeyDown("space")|| Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow)) && onGround)
            {
            //Vector3 jumpMovement = new Vector3(0.0f, 1.0f, 0.0f);
            rb2d.AddForce(Vector2.up * jumpSpeed,ForceMode2D.Impulse);
            onGround = false;
            }
        }
        else
        {
           
                //rb2d.AddForce(Vector2.up * 2);
                var verticalButtonPress = Input.GetAxis("Vertical");

                float moveVertical = verticalButtonPress * speed;
                rb2d.velocity = new Vector2(rb2d.velocity.x, moveVertical);
           
            
        }
       

       
        //jumpCheck = transform.position.y - transform.localScale.y / 2;
    }
    private void LateUpdate()
    {
        jumpCheck2 = rb2d.velocity.y;
        transform.rotation = rotation;
    }
    public bool getOnGround()
    {
        return onGround;
    }
    public void ChangeFlight()
    {
        flight = !flight;
        if (flight)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }else
        {
            GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //print("COLLIDIED");
        if (collision.tag != "EditorOnly")
            onGround = true;
    }
    /*
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "EditorOnly")
            onGround = true;
    }*/

    //Check if the object has left the ground
    void OnTriggerExit2D(Collider2D collisionInfo)
    {
        if (collisionInfo.tag != "EditorOnly")
            onGround = false;
    }
    IEnumerator delayJump()
    {
        yield return new WaitForSecondsRealtime(.1f);
       // onGround = false;
    }
}

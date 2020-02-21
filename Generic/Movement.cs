using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {
    private Rigidbody2D rb2d;
    private float horizontalButtonPress;
    public float speedY;
    private float freeze = 1, freezeY = 1;
    Animator anim;
    [HideInInspector] public bool facingRight = true;
    public float speed = 10;
    [ReadOnly] public static float baseSpeed = 10;
    Thread slow,freezeMod,fly;
    public bool explosion;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //Store the current horizontal input in the float moveHorizontal.
        /*//UnComment for networking
        if (!hasAuthority)
        {
            return;
        }*/
        if (isLocalPlayer == false)
        {
            if (rb2d.velocity.x > 0 && !facingRight)
                Flip();
            else if (rb2d.velocity.x < 0 && facingRight)
                Flip();

            return;
        }

        horizontalButtonPress = Input.GetAxis("Horizontal");

        float moveHorizontal = horizontalButtonPress * speed;
        speedY = rb2d.velocity.y;
       // print("VX: " + rb2d.velocity.x);
        anim.SetFloat("speedY",speedY);
        anim.SetFloat("speed",Mathf.Abs(moveHorizontal));
        if (explosion)
        {
           // rb2d.velocity = new Vector2(moveHorizontal + explosion, rb2d.velocity.y * freezeY);
           Invoke("EndExplosion",.3f);
        }
        else
        {
            rb2d.velocity = new Vector2 (moveHorizontal* freeze, rb2d.velocity.y * freezeY);
        }
        
        //rb2d.AddForce(new Vector2( moveHorizontal,0),ForceMode2D.Impulse);
        //transform.position += new Vector3( moveHorizontal,0);

        if (moveHorizontal > 0 && !facingRight)
            Flip();
        else if (moveHorizontal < 0 && facingRight)
            Flip();
    }
    public void EndExplosion()
    {
        explosion = false;
    }

    public float getSpeed()
    {
        return speed;
    }
    public float GetBaseSpeed()
    {
        return baseSpeed;
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public float GetHorizButtonPress()
    {   
        return horizontalButtonPress;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public IEnumerator SlowMovement(float time, float amount)
    {
        freeze = 0;
        print("FREEZE");
        
        yield return new WaitForSecondsRealtime(time);
        print("UNFREEZE");
        freeze = 1;
        slow.Abort();
    }
    public void moveSlow(float time, float amount)
    {
        slow = new Thread(() => {
        StartCoroutine(SlowMovement(time, amount));
        });

        slow.Start();

    }
    public IEnumerator freezeMovementForSeconds(float time)
    {
        freeze = 0;
        print("FREEZE");
        yield return new WaitForSecondsRealtime(time);
        print("UNFREEZE");
        freeze = 1;
    }
    public void freezeMovement(float time)
    {
        StartCoroutine(freezeMovementForSeconds(time));
    }

    public IEnumerator freezeMovementForSecondsY(float time)
    {
        freezeY = 0;
        print("FREEZE");
        yield return new WaitForSecondsRealtime(time);
        print("UNFREEZE");
        freezeY = 1;
    }
    public void freezeMovementY(float time)
    {
        StartCoroutine(freezeMovementForSecondsY(time));
    }

    public IEnumerator freezeBothMovementForSeconds(float time)
    {
        freezeY = 0;
        freeze = 0;
        print("FREEZE");
        yield return new WaitForSecondsRealtime(time);
        print("UNFREEZE");
        freeze = 1;
        freezeY = 1;
        freezeMod.Abort();
    }
    public void freezeBothMovement(float time)
    {
        freezeMod = new Thread(() => {
        StartCoroutine(freezeBothMovementForSeconds(time));
        });
        freezeMod.Start();
        
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovementNet : NetworkBehaviour
{
    private  Rigidbody2D rb2d;
    public float speedY;
    private float freeze;
    private  float freezeY = 1;
    public bool localPlayer;
    Animator anim;
    [HideInInspector] public bool facingRight = true;
    public float speed = 10;
    float baseSpeed = 10;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("11111111111111111111111111111111111" + localPlayerAuthority);
        
        if (hasAuthority == false)
        {
            if (rb2d.velocity.x > 0 && !facingRight)
                Flip();
            else if (rb2d.velocity.x < 0 && facingRight)
                Flip();

            return;
        }

        //Store the current horizontal input in the float moveHorizontal.

        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        speedY = rb2d.velocity.y;

            anim.SetFloat("speedY", speedY);
            anim.SetFloat("speed", Mathf.Abs(moveHorizontal));
            rb2d.velocity = new Vector2(moveHorizontal, rb2d.velocity.y * freezeY);


            if (moveHorizontal > 0 && !facingRight)
                Flip();
            else if (moveHorizontal < 0 && facingRight)
                Flip();
        
    }

    public float getSpeed()
    {
        return speed;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
    }
    public void freezeBothMovement(float time)
    {
        StartCoroutine(freezeBothMovementForSeconds(time));
    }
}

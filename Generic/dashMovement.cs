using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class dashMovement : NetworkBehaviour {

    Rigidbody2D rb2d;
    bool leftPressed = false;
    public float speedOfBoost = 50;
    private Vector2 boostSpeed;
    private bool canBoost = true;
    private float dashDirection;
    private float boostCooldown = 3;
    private float buttonTimer = 0;
    private float buttonDelay = .25f;
    private bool ButtonPressed = false;
    bool inTime = false;

    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D>();
        boostSpeed = new Vector2(speedOfBoost, 0);
    }
	
	// Update is called once per frame
	void Update() {
        if (!isLocalPlayer)
        {
            return;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");

        //For double tapping A to dash(dashing Right is NOT done)
        /*
         if (buttonDelay > buttonTimer&&ButtonPressed)
         {
             buttonTimer += Time.deltaTime;
             //print("Timer running " + buttonTimer);

             inTime = true;
         }
         if(buttonTimer > buttonDelay)
         {
             print("Timer Reset");
             buttonTimer = 0;
             inTime = false;
             ButtonPressed = false;
         }
         print("inTime: " + inTime);
         if (Input.GetKeyUp("a"))
         {

             print("A pressed once");
             leftPressed = true;
             ButtonPressed = true;
         }
         if (Input.GetKeyDown("a")&&leftPressed&&inTime)
         {
             print("A pressed twice");
             leftPressed = false;
             dashDirection = -1;
             //rb2d.velocity = new Vector2(0,0);
             //rb2d.AddForce(Vector2.left * 50, ForceMode2D.Impulse);
             if(canBoost)
                 StartCoroutine(Dash(.05f));
         }
         */
        if (Input.GetKeyDown("left shift"))
        {
           // print("A pressed twice");
            if(GetComponent<Movement>().facingRight)
            dashDirection = 1;
            else
            dashDirection = -1;
            //rb2d.velocity = new Vector2(0,0);
            //rb2d.AddForce(Vector2.left * 50, ForceMode2D.Impulse);
            boostSpeed = new Vector2(speedOfBoost, 0);
            if (canBoost)
                StartCoroutine(Dash(.05f));
        }
    }
    IEnumerator Dash(float boostDur) //Coroutine with a single input of a float called boostDur, which we can feed a number when calling
    {
        GetComponent<Movement>().explosion = true;
        float time = 0; //create float to store the time this coroutine is operating
        canBoost = false; //set canBoost to false so that we can't keep boosting while boosting

        while (boostDur > time) //we call this loop every frame while our custom boostDuration is a higher value than the "time" variable in this coroutine
        {
            time += Time.deltaTime; //Increase our "time" variable by the amount of time that it has been since the last update
            rb2d.velocity = boostSpeed*dashDirection; //set our rigidbody velocity to a custom velocity every frame, so that we get a steady boost direction like in Megaman
            yield return 0; //go to next frame
        }
        yield return new WaitForSeconds(boostCooldown); //Cooldown time for being able to boost again, if you'd like.
        canBoost = true; //set back to true so that we can boost again.
        GetComponent<Movement>().explosion = false;
    }
}

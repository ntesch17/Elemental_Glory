using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwDaggers : MonoBehaviour {
    public GameObject dagger;
    public float Direction;
    public Vector2 daggerSpeed = new Vector2 (15, 0);
    public int numberOfDaggers;
    public Transform spawnPoint;
    [HideInInspector] public bool canThrowDagger;
    // Use this for initialization
    void Start () {
		//spawnPoint = GetComponentInChildren<Transform>();
        canThrowDagger = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire2") &&canThrowDagger)
        {
            print("Throw Them Daggers");
            if (GetComponent<Movement>().facingRight)
                Direction = 1;
            else
                Direction = -1;

            StartCoroutine(ThrowDagger());
          //  StartCoroutine(DaggerDelay());
        }
       
    }
    IEnumerator DaggerDelay()//unNeeded integrated with throw dagger
    {
        canThrowDagger = false;
        GetComponent<Movement>().freezeMovement(.3f);
        yield return new WaitForSecondsRealtime(.3f);
        canThrowDagger = true;
    }
    IEnumerator ThrowDagger()
    {
        canThrowDagger = false;
        GetComponent<Movement>().freezeBothMovement(numberOfDaggers * .03f);
        //GetComponent<Movement>().freezeMovementY(numberOfDaggers * .03f);

        for (int i = 0; i <= numberOfDaggers-1; i++)
        {
            var randomPos = new Vector3 (spawnPoint.transform.position.x, spawnPoint.transform.position.y + (Random.Range(-.2f,.2f)), spawnPoint.transform.position.z);
            var disDagger = Instantiate(dagger, randomPos,  new Quaternion(0,0,0,0));
            var rb2d = disDagger.GetComponent<Rigidbody2D>();
            rb2d.velocity = daggerSpeed * Direction;
            yield return new WaitForSecondsRealtime(.03f);
        }
        yield return new WaitForSecondsRealtime(.6f);
        canThrowDagger = true;
    }
}

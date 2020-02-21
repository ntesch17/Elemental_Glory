using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject Player;
    public float turnRate, shakeX, shakeY;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //this.gameObject.transform.position = new Vector3(Player.transform.position.x + .13f, Player.transform.position.x + .12f, Player.transform.position.z);

        if (Player != null)
        {
        this.gameObject.transform.position = new Vector3(Player.transform.position.x + shakeX,Player.transform.position.y + shakeY, -10);

        this.gameObject.transform.Rotate(new Vector3(0,0, turnRate));
        }

           
    }
}

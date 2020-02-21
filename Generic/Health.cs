using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float health;
    public GameObject orbs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health<=0)
        {
            //Destroy(orbs);
           
        }
	}
    public void damage(float dmg)
    {
        health -= dmg;
       // StartCoroutine(makeInvincibe());
    }
    public void damage(float dmg,GameObject enemy)
    {
        
           // float force = GetComponent<CollideWithEnemy>().force;
            Vector2 dir = transform.position - enemy.transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody2D>().AddForce(dir * 50, ForceMode2D.Impulse);
        damage(dmg);
        
    }
    IEnumerator makeInvincibe()
    {
        this.gameObject.layer = 8;
        yield return new WaitForSecondsRealtime(.75f);
        this.gameObject.layer = 11;

    }
    public void heal(float heal)
    {
        health += heal;
    }
    public float getHealth()
    {
        return health;
    }

}

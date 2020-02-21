using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public float health;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
       
    }
    public void damage(float dmg)
    {
        print("damaged");
        health = health - dmg;
    }
    public void heal(float heal)
    {
        health = health + heal;
    }
    public float getHealth()
    {
        return health;
    }

}

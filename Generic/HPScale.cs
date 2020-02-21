using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScale : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            var maxHealth = Player.GetComponent<PlayerController>().GetMaxHealth();
            var health = Player.GetComponent<PlayerController>().GetHealth();
            var scale = health / maxHealth;

            this.transform.localScale = new Vector3(scale, this.transform.localScale.y, this.transform.localScale.z);
        }

    }
}

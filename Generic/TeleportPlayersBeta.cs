using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayersBeta : MonoBehaviour
{
    public Transform teleportLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision.transform.GetComponent<PlayerController>().ID==1)
            collision.transform.position = teleportLocation.position;

            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer2 : MonoBehaviour
{
    public GameObject Player;
    float posX, posY, posZ;

    // Start is called before the first frame update
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
            this.gameObject.transform.position = new Vector3(Player.transform.position.x + .13f, Player.transform.position.y + 2f, Player.transform.position.z);
       // if(Player!=null)
        //this.gameObject.transform.position = new Vector3(Player.transform.position.x + posX, Player.transform.position.y + posY, Player.transform.position.z + posZ);

        
    }
}

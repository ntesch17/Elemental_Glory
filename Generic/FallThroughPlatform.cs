using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThroughPlatform : MonoBehaviour
{
    bool falling;
    // Start is called before the first frame update
    void Start()
    {
        falling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S) && !falling)
        {
            falling = true;
            this.gameObject.layer = 9;
            Invoke("StopFalling",.5f);
        }
    }
    void StopFalling()
    {
        this.gameObject.layer = 0;
        falling = false;
    }
}

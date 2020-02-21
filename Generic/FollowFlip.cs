using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFlip : MonoBehaviour
{
    public GameObject followedObject;
    public float xScale;

    private void Awake()
    {
        xScale = this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (followedObject.GetComponent<Movement>().facingRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = xScale;
            transform.localScale = theScale;
            //transform.rotation = new Quaternion(this.transform.rotation.x, 90, 0, 0);

        }
        else if (!followedObject.GetComponent<Movement>().facingRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -xScale;
            transform.localScale = theScale;
            //transform.eulerAngles = new Vector3(this.transform.rotation.x, 270, 0);
        }
    }
}

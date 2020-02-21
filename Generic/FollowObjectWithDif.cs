using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectWithDif : MonoBehaviour
{
    public GameObject followedObject;
    public float x, y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3( followedObject.transform.position.x + x, followedObject.transform.position.y + y);
    }
}

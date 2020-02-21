using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireBall : MonoBehaviour
{
    public GameObject target;
    public float step;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
           // transform.position = Vector3.MoveTowards(transform.position, target.transform.position, .03f);
            transform.position -= (this.transform.position - target.transform.position).normalized * .1f;
        }
        
    }
}

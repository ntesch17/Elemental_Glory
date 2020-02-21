using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePls : MonoBehaviour
{
    public float decay, max, min;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(decay, 0), Space.World);
        if (this.transform.position.x > max)
        {
            decay *= -1;
            transform.Translate(new Vector3(decay*2, 0), Space.World);
        }

        if (this.transform.position.x < min)
        {
            decay *= -1;
            transform.Translate(new Vector3(decay*2, 0), Space.World);
        }
    }
}

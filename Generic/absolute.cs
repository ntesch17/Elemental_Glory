using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class absolute : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // var xScale = this.transform.localScale.x;
        if (player.transform.localScale.x < 0)
        {
            Vector3 newScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
            this.transform.localScale = newScale;
        }
        else
        {
            Vector3 newScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            this.transform.localScale = newScale;
        }
    }
}

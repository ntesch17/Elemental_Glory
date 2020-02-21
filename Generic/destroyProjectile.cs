using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //Destroy(this, 3);
    }

    public void Shot()
    {
        Destroy(this.gameObject, 3);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        if(other.tag=="Player")
        print("Fire ember collided with..." + other.name);
    }
}

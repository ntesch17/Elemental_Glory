using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiersOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().AddModifier(GetComponent<Modifier>());
            Destroy(this.gameObject);
        }
    }
}

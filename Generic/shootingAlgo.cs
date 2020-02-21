using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingAlgo : MonoBehaviour
{   public GameObject object1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos2D = new Vector3(pz.x, pz.y);
        Vector2 diff = mousePos2D - this.transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        

        if (Input.GetMouseButtonUp(0))
        {
            GameObject orb = Instantiate(object1, this.transform.position, new Quaternion(0,0,0,0));
            orb.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            var rb2d = orb.GetComponent<Rigidbody2D>();
            rb2d.gravityScale = 0;//shoots straight, 1 for gravity, 10 for unique abilities i.e. Lightning bolt
            rb2d.velocity = diff * 10;
            Physics2D.IgnoreCollision(orb.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class shootingNet : NetworkBehaviour
{

    Vector3 pz;
    Vector3 mousePos2D;
    Vector2 diff;
    float rot_z;

    public GameObject object1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (!hasAuthority)
        {
            return;
        }



        if (Input.GetMouseButtonUp(0))
        {



            Vector2 _target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 _myPos = new Vector2(transform.position.x, transform.position.y + 1);
            Vector2 _direction = _target - _myPos;
            Vector3 _rot = transform.rotation.eulerAngles;




            CmdFire(_myPos, _direction, _rot);





        }

    }



    [Command]
    void CmdFire(Vector2 _myPos, Vector2 _myDir, Vector3 _rot)
    {
       // RpcFire(_myPos, _myDir, _rot);
        GameObject orb = Instantiate(object1, _myPos, Quaternion.Euler(_rot));
        var _direction = mousePos2D - this.transform.position;
        orb.GetComponent<Rigidbody2D>().velocity = _myDir * 4f;

        orb.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        var rb2d = orb.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0; //shoots straight, 1 for gravity, 10 for unique abilities i.e. Lightning bolt
        rb2d.velocity = _myDir * 10;
        Physics2D.IgnoreCollision(orb.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Debug.Log("something is done");
        NetworkServer.Spawn(orb);
        orb.GetComponent<destroyProjectile>().Shot();
        // spawn the bullet on the clients

        // make bullet disappear after 2 seconds
        Destroy(orb, 2.0f);
    }

    [ClientRpc]
    void RpcFire(Vector2 _myPos, Vector2 _myDir, Vector3 _rot)
    {
        // create the bullet object from the bullet prefab

        // make the bullet move away in front of the player

        
    }




}


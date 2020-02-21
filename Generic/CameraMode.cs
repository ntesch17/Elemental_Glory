using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMode : MonoBehaviour
{
    public HotKeyCycle<PlayerController> CameraPositions;// = new HotKeyCycle<GameObject>();
    public Camera main;
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
        //CameraPositions = new HotKeyCycle<GameObject>()
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {

            if (Input.GetButtonDown("InvPrev"))
            {
                CameraPositions.Prev();
                main.GetComponent<FollowPlayer>().Player = CameraPositions.Current().gameObject;
            }
            else if (Input.GetButtonDown("InvNext"))
            {
                CameraPositions.Next();
                main.GetComponent<FollowPlayer>().Player = CameraPositions.Current().gameObject;
            }
        }
        
    }

    public void SetCameraPositions(PlayerController[] list)
    {
        foreach(PlayerController help in list)
        {
            print("Pos: " + help.transform.position);
        }

        CameraPositions = new HotKeyCycle<PlayerController>(list);
        //main.GetComponent<FollowPlayer>().Player = CameraPositions.Current().gameObject;
    }
}

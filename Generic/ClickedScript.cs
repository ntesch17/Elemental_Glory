using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // print("clicked");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //print("names: " + this.gameObject.name);
                print("hit name: " + hit.transform.name);
                if (hit.transform.name == this.gameObject.name)
                {
                    
                    print("Selected Slot: " + hit.transform.name);
                   
                }
            }
        }
    }

}

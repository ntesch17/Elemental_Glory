using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSlashSpell : Spell
{
    // Start is called before the first frame update
    public override void OnAwake()
    {
        base.OnAwake();
        print("Pre: " + transform.eulerAngles.z);
       
    }


}

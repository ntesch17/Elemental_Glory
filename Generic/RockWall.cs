using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWall : Dummy
{
    // Start is called before the first frame update
    void Awake()
    {
        SetHPS(0);
        SetMPS(0);
        CmdSetHP(50);
    }

    public override void AddModifier(Modifier mod)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

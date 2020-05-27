using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoCached
{
    public override void OnTick()
    {    
        base.OnTick();
        Debug.Log("1");
    }

    public override void OnFixedTick()
    {
        Debug.Log("2");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using uGames.Interfaces;
using UnityEngine;

public class MonoCached : MonoBehaviour
{ 
    public static List<MonoCached> updates = new List<MonoCached>(1000);
    public static List<MonoCached> updatesFixed = new List<MonoCached>();
    public static List<MonoCached> updatesLate = new List<MonoCached>();
    private void OnEnable()
    {
        updates.Add(this);
    }

    private void OnDisable()
    {
        updates.Remove(this);
    }

    public void Tick()
    {
        OnTick();
    }

    public void FixedTick()
    {
        OnFixedTick();
    }

    public void LateTick()
    {
        OnLateTick();
    }
    
    public virtual void OnTick()
    {
        Debug.Log("Update");
    }
    public virtual void OnFixedTick()
    {
        Debug.Log("FixedUpdate");
    }
    public virtual void OnLateTick()
    {
        
    }


}

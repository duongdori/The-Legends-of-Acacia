using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MyMonoBehaviour
{
    protected Core core;

    protected override void Awake()
    {
        base.Awake();
        
        core = transform.parent.GetComponent<Core>();

        if (core == null)
        {
            // Debug.LogError("There is no Core on the parent");
        }
    }
}

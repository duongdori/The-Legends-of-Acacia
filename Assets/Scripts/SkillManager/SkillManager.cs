using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MyMonoBehaviour
{
    private static SkillManager instance;
    public static SkillManager Instance => instance;
    
    protected override void Awake()
    {
        base.Awake();
        
        if (instance != null)
        {
            Debug.LogError("There is more than one SkillManager instance");
        }
        instance = this;
    }
}

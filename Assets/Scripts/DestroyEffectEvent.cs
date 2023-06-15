using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffectEvent : MonoBehaviour
{
   
    //Call by animation event
    private void DestroyEffect()
    {
        Destroy(transform.parent.gameObject);
    }
}

using System;
using UnityEngine;

public class MyMonoBehaviour : MonoBehaviour
{
        protected virtual void Awake()
        {
                LoadComponents();
        }
        protected virtual void Start()
        {
                LoadComponents();
        }
        protected virtual void Reset()
        {
                LoadComponents();
        }

        protected virtual void LoadComponents()
        {
                
        }
}
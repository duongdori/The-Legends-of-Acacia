using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MyMonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float moveSpeed = 7f;
    
    private Vector2 movement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerAnimator();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        playerAnimator.SetFloat("Horizontal", movement.x);
        playerAnimator.SetFloat("Vertical", movement.y);
        playerAnimator.SetFloat("MoveSpeed", movement.sqrMagnitude);

        transform.position += new Vector3(movement.x, movement.y, 0) * (moveSpeed * Time.deltaTime);
    }

    private void LoadPlayerAnimator()
    {
        if(playerAnimator != null) return;
        playerAnimator = GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadPlayerAnimator", gameObject);
    }
}

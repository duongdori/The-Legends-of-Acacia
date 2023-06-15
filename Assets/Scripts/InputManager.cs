using System;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region Singleton Variables
    
    private static InputManager instance;
    public static InputManager Instance => instance;
    
    #endregion

    #region Input Variables
    
    private Vector2 rawMovementInput;
    public Vector2 RawMovementInput => rawMovementInput;
    
    private int normalizeInputX;
    public int NormalizeInputX => normalizeInputX;
    
    private int normalizeInputY;
    public int NormalizeInputY => normalizeInputY;

    private bool jumpInput;
    public bool JumpInput => jumpInput;
    
    private bool jumpInputStop;
    public bool JumpInputStop => jumpInputStop;
    
    private bool grabInput;
    public bool GrabInput => grabInput;
    
    private bool dashInput;
    public bool DashInput => dashInput;
    
    private bool[] attackInputs;
    public bool[] AttackInputs => attackInputs;
    
    private bool primaryAttackInput;
    public bool PrimaryAttackInput => primaryAttackInput;
    
    #endregion
    
    #region Check Time Variables
    
    private float inputHoldTime = 0.2f;
    private float jumpInputStartTime;
    
    #endregion
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one InputManager instance");
        }
        instance = this;
    }

    private void Start()
    {
        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        attackInputs = new bool[count];
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // attackInputs[(int)CombatInputs.primary] = true;
            primaryAttackInput = true;
        }

        if (context.canceled)
        {
            // attackInputs[(int)CombatInputs.primary] = false;
            primaryAttackInput = false;
        }
    }
    
    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            attackInputs[(int)CombatInputs.secondary] = true;
        }
        if (context.canceled)
        {
            attackInputs[(int)CombatInputs.primary] = false;
        }
    }

    public void UseAttackInput()
    {
        primaryAttackInput = false;
        attackInputs[(int)CombatInputs.primary] = false;
        attackInputs[(int)CombatInputs.secondary] = false;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        rawMovementInput = context.ReadValue<Vector2>();

        normalizeInputX = Mathf.RoundToInt(rawMovementInput.x);
        normalizeInputY = Mathf.RoundToInt(rawMovementInput.y);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpInput = true;
            jumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            jumpInputStop = true;
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            grabInput = true;
        }

        if (context.canceled)
        {
            grabInput = false;
        }
    }
    
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            dashInput = true;
        }

        if (context.canceled)
        {
            dashInput = false;
        }
    }
    public void UseDashInput() => dashInput = false;
    public void UseJumpInput() => jumpInput = false;

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            jumpInput = false;
        }
    }
}
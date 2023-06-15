using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity, ISaveManager
{
    #region State Variables

    private PlayerStateMachine stateMachine;
    public PlayerStateMachine StateMachine => stateMachine;
    
    private PlayerIdleState idleState;
    public PlayerIdleState IdleState => idleState;
    
    private PlayerMoveState moveState;
    public PlayerMoveState MoveState => moveState;
    
    private PlayerJumpState jumpState;
    public PlayerJumpState JumpState => jumpState;
    
    private PlayerInAirState inAirState;
    public PlayerInAirState InAirState => inAirState;
    
    private PlayerLandState landState;
    public PlayerLandState LandState => landState;
    
    private PlayerDashState dashState;
    public PlayerDashState DashState => dashState;
    
    private PlayerWallSlideState wallSlideState;
    public PlayerWallSlideState WallSlideState => wallSlideState;

    private PlayerWallJumpState wallJumpState;
    public PlayerWallJumpState WallJumpState => wallJumpState;
    
    private PlayerLedgeClimbState ledgeClimbState;
    public PlayerLedgeClimbState LedgeClimbState => ledgeClimbState;
    
    private PlayerDeadState deadState;
    public PlayerDeadState DeadState => deadState;

    private PlayerAttackState primaryAttackState;
    public PlayerAttackState PrimaryAttackState => primaryAttackState;
    
    private PlayerAttackState secondaryAttackState;
    public PlayerAttackState SecondaryAttackState => secondaryAttackState;
    
    #endregion

    #region Components

    [SerializeField] private PlayerData playerData;
    public PlayerData PlayerData => playerData;

    [SerializeField] private InventorySystem inventorySystem;
    public InventorySystem InventorySystem => inventorySystem;

    #endregion

    [SerializeField] private Transform startPoint;
    private bool isBusy;
    public bool IsBusy => isBusy;

    public bool isInteract = false;
    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "idle", playerData);
        moveState = new PlayerMoveState(this, stateMachine, "move", playerData);
        jumpState = new PlayerJumpState(this, stateMachine, "inAir", playerData);
        inAirState = new PlayerInAirState(this, stateMachine, "inAir", playerData);
        landState = new PlayerLandState(this, stateMachine, "land", playerData);
        dashState = new PlayerDashState(this, stateMachine, "dash", playerData);
        wallSlideState = new PlayerWallSlideState(this, stateMachine, "wallSlide", playerData);
        wallJumpState = new PlayerWallJumpState(this, stateMachine, "inAir", playerData);
        ledgeClimbState = new PlayerLedgeClimbState(this, stateMachine, "ledgeClimbState", playerData);
        deadState = new PlayerDeadState(this, stateMachine, "die", playerData);
        primaryAttackState = new PlayerAttackState(this, stateMachine, "attack", playerData);
        secondaryAttackState = new PlayerAttackState(this, stateMachine, "attack", playerData);
    }

    protected override void Start()
    {
        base.Start();

        // transform.position = startPoint.position;
        
        stateMachine.Initialize(idleState);
    }
    
    protected override void Update()
    {
        base.Update();
        if(PauseMenu.GameIsPause) return;
        stateMachine.CurrentState.LogicUpdate();
    }
    
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        
        stateMachine.CurrentState.PhysicsUpdate();
    }

    public IEnumerator BusyFor(float second)
    {
        isBusy = true;
        yield return new WaitForSeconds(second);
        isBusy = false;
    }
    public void SetColliderHeight(float height)
    {
        Vector2 center = characterCollider.offset;
        workspace.Set(characterCollider.size.x, height);

        center.y += (height - characterCollider.size.y) / 2;
        
        characterCollider.size = workspace;
        characterCollider.offset = center;
    }

    public void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, playerData.attackCheckRadius);

        foreach (Collider2D hit in colliders)
        {
            Enemy enemyInfo = hit.GetComponent<Enemy>();

            if (enemyInfo != null)
            {
                stats.DoDamage(enemyInfo.Stats);
            }
        }
    }

    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deadState);
        LoadStartScene();
        SaveManager.Instance.SaveGame();
    }

    private void LoadStartScene()
    {
        if (LevelManager.Instance.GetCurrentSceneIndex() < LevelManager.Instance.startSceneIndex)
        {
            StartCoroutine(LevelManager.Instance.LoadStartScene(1.5f, LevelManager.Instance.GetCurrentSceneIndex()));
            inventorySystem.RemoveAllItem();
        }
        else
        {
            StartCoroutine(LevelManager.Instance.LoadStartScene(1.5f, LevelManager.Instance.startSceneIndex));
            inventorySystem.RemoveAllItem();
        }
    }

    public void InitialDustEffect(GameObject effect)
    {
        Instantiate(effect, groundCheck.position, Quaternion.identity);
    }

    public void CheckInteract()
    {
    }
    public void AnimationTrigger() => stateMachine.CurrentState.AnimationTrigger();
    public void AnimationFinishTrigger() => stateMachine.CurrentState.AnimationFinishTrigger();

    #region Load Components

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerData();
        baseData = playerData;
        LoadInventorySystem();
        LoadStartPoint();
    }
    
    private void LoadPlayerData()
    {
        if(playerData != null) return;
        playerData = Resources.Load<PlayerData>("SO/PlayerData");
        Debug.LogWarning(transform.name + " LoadPlayerData", gameObject);
    }
    
    private void LoadInventorySystem()
    {
        if(inventorySystem != null) return;
        inventorySystem = FindObjectOfType<InventorySystem>().GetComponent<InventorySystem>();
        Debug.LogWarning(transform.name + " LoadInventorySystem", gameObject);
    }
    
    private void LoadStartPoint()
    {
        if(startPoint != null) return;
        startPoint = GameObject.Find("LevelStartPoint").transform;
        Debug.LogWarning(transform.name + " LoadStartPoint", gameObject);
    }

    #endregion

    public void LoadData(GameData data)
    {
        //transform.position = data.playerPos;
    }

    public void SaveData(ref GameData data)
    {
        // data.playerPos = transform.position;
        data.sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}

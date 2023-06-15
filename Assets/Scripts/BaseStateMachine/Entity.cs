using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Entity : MyMonoBehaviour
{

    #region Components

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D RB => rb;
    
    [SerializeField] protected Animator anim;
    public Animator Anim => anim;
    
    [SerializeField] protected BoxCollider2D characterCollider;
    public BoxCollider2D CharacterCollider => characterCollider;
    
    protected BaseData baseData;
    public BaseData BaseData => baseData;
    
    [SerializeField] protected EntityFX entityFX;
    public EntityFX EntityFX => entityFX;
    
    [SerializeField] protected CharacterStats stats;
    public CharacterStats Stats => stats;

    #endregion
    
    #region Collision Info
    [Header("Collision Info")]
    [SerializeField] protected Transform groundCheck;
    public Transform GroundCheck => groundCheck;

    [SerializeField] protected Transform wallCheck;
    public Transform WallCheck => wallCheck;

    [SerializeField] protected Transform ledgeCheck;
    public Transform LedgeCheck => ledgeCheck;
    
    [SerializeField] protected Transform attackCheck;
    public Transform AttackCheck => attackCheck;

    #endregion
    
    #region Other Variables
    
    protected int facingDirection;
    public int FacingDirection => facingDirection;
    
    protected Vector2 workspace;

    private Vector2 currentVelocity;
    public Vector2 CurrentVelocity => currentVelocity;
    
    #endregion

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        facingDirection = 1;

        entityFX = GetComponent<EntityFX>();
        stats = GetComponent<CharacterStats>();
    }

    protected virtual void Update()
    {
        currentVelocity = rb.velocity;
    }
    
    protected virtual void FixedUpdate()
    {
    }

    public virtual void DamageEffect()
    {
        AudioManager.Instance.PlaySFX(7);
        StartCoroutine(entityFX.HurtFX());
    }

    public virtual void Die()
    {
        
    }

    #region Collision Detected

    public bool IsGroundDetected()
    {
        return Physics2D.OverlapCircle(groundCheck.position, baseData.groundCheckRadius, baseData.whatIsGround);
    }
    public bool IsWallDetected()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, baseData.wallCheckDistance, baseData.whatIsGround);
    }
    
    public bool IsWallBackDetected()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * -facingDirection, baseData.wallCheckDistance, baseData.whatIsGround);
    }

    public bool IsLedgeDetected()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.right * facingDirection, baseData.wallCheckDistance, baseData.whatIsGround);
    }
    
    protected virtual void OnDrawGizmos()
    {
        if(!baseData) return;
        
        Gizmos.DrawWireSphere(groundCheck.position, baseData.groundCheckRadius);
        Gizmos.DrawWireSphere(attackCheck.position, baseData.attackCheckRadius);
        Gizmos.DrawRay(wallCheck.position, new Vector3(baseData.wallCheckDistance * facingDirection, 0f));
        Gizmos.DrawRay(ledgeCheck.position, new Vector3(baseData.wallCheckDistance * facingDirection, 0f));
    }

    #endregion

    #region Check Flip

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != facingDirection)
        {
            Flip();
        }
    }
    
    public void Flip()
    {
        facingDirection *= -1;
        rb.transform.localScale = new Vector3(facingDirection, 1, 1);
    }

    #endregion

    #region Set Velocity

    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
        currentVelocity = Vector2.zero;
    }
    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        rb.velocity = workspace;
        currentVelocity = workspace;
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, currentVelocity.y);
        rb.velocity = workspace;
        currentVelocity = workspace;
    }
    public void SetVelocityY(float velocity)
    {
        workspace.Set(currentVelocity.x, velocity);
        rb.velocity = workspace;
        currentVelocity = workspace;
    }

    #endregion

    #region Load Components

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigidbody2D();
        LoadAnimator();
        LoadCollider();
        LoadGroundCheck();
        LoadWallCheck();
        LoadLedgeCheck();
        LoadAttackCheck();
    }
    
    private void LoadRigidbody2D()
    {
        if(rb != null) return;
        rb = GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + " LoadRigidbody2D", gameObject);
    }
    private void LoadAnimator()
    {
        if(anim != null) return;
        anim = GetComponentInChildren<Animator>();
        Debug.LogWarning(transform.name + " LoadAnimator", gameObject);
    }
    
    private void LoadCollider()
    {
        if(characterCollider != null) return;
        characterCollider = GetComponent<BoxCollider2D>();
        Debug.LogWarning(transform.name + " LoadCollider", gameObject);
    }

    private void LoadGroundCheck()
    {
        if(groundCheck != null) return;
        groundCheck = transform.Find("GroundCheck");
        Debug.LogWarning(transform.name + " LoadGroundCheck", gameObject);
    }
    
    private void LoadWallCheck()
    {
        if(wallCheck != null) return;
        wallCheck = transform.Find("WallCheck");
        Debug.LogWarning(transform.name + " LoadWallCheck", gameObject);
    }
    
    private void LoadLedgeCheck()
    {
        if(ledgeCheck != null) return;
        ledgeCheck = transform.Find("LedgeCheck");
        Debug.LogWarning(transform.name + " LoadLedgeCheck", gameObject);
    }
    
    private void LoadAttackCheck()
    {
        if(attackCheck != null) return;
        attackCheck = transform.Find("AttackCheck");
        Debug.LogWarning(transform.name + " LoadAttackCheck", gameObject);
    }

    #endregion
    
}
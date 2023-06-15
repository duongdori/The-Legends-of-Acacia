using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyWeapon enemyWeapon;

    protected bool isMaxDetectedPlayer;
    protected bool isMinDetectedPlayer;

    public bool isAttackDone;


    public EnemyAttackState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData) : base(enemy, stateMachine, animBoolName, enemyData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        isAttackDone = false;
        enemyBase.SetVelocityZero();
        enemyWeapon.EnterWeapon();
        // Debug.Log("Attack Player");
    }
    public override void Exit()
    {
        base.Exit();
        enemyWeapon.ExitWeapon();
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if(!isAttackDone) return;
        
        // stateMachine.ChangeState(enemyBase.DetectedState);
        //
        // if (!isMinDetectedPlayer && !isMaxDetectedPlayer)
        // {
        //     stateMachine.ChangeState(enemyBase.IdleState);
        // }
        
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    protected override void DoChecks()
    {
        base.DoChecks();
        // isMaxDetectedPlayer = CheckMaxDetectedPlayer();
        // isMinDetectedPlayer = CheckMinDetectedPlayer();
    }

    public void SetWeapon(EnemyWeapon weapon)
    {
        this.enemyWeapon = weapon;
        enemyWeapon.InitializeWeapon(this);
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        isAttackDone = true;
    }
}
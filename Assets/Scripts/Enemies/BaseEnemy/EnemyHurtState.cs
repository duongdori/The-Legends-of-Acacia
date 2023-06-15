using UnityEngine;

public class EnemyHurtState : EnemyState
{
    protected bool isMaxDetectedPlayer;
    protected bool isMinDetectedPlayer;


    public EnemyHurtState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData) : base(enemy, stateMachine, animBoolName, enemyData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // core.Movement.SetVelocityZero();
        // core.Combat.isHurt = false;
        // Debug.Log("Hurt");
    }
    public override void Exit()
    {
        base.Exit();
        
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isAnimationFinished) return;

        // if (isMinDetectedPlayer)
        // {
        //     stateMachine.ChangeState(enemyBase.AttackState);
        // }
        // else if (isMaxDetectedPlayer && !isMinDetectedPlayer)
        // {
        //     stateMachine.ChangeState(enemyBase.DetectedState);
        // }
        // else if (!isMinDetectedPlayer && !isMaxDetectedPlayer)
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
}
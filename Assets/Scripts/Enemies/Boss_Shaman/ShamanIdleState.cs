using UnityEngine;

public class ShamanIdleState : ShamanGroundedState
{
    public ShamanIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData, Boss_Shaman enemy) : base(enemyBase, stateMachine, animBoolName, enemyData, enemy)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        stateTimer = RandomIdleTime();
        enemy.SetVelocityZero();
    }
    
    public override void Exit()
    {
        base.Exit();
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (stateTimer <= 0)
        {
            stateMachine.ChangeState(enemy.MoveState);
        }
    }
    
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    protected override void DoChecks()
    {
        base.DoChecks();
        isGrounded = enemy.IsGroundDetected();
        isTouchingWall = enemy.IsWallDetected();
        isTouchingLedge = enemy.IsLedgeDetected();
    }
    
    private float RandomIdleTime()
    {
        return Random.Range(enemyData.minIdleTime, enemyData.maxIdleTime);
    }
}
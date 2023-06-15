using UnityEngine;

public class ShamanMoveState : ShamanGroundedState
{
    public ShamanMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData, Boss_Shaman enemy) : base(enemyBase, stateMachine, animBoolName, enemyData, enemy)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (!enemy.IsGroundDetected() || enemy.IsWallDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        enemy.SetVelocityX(enemyData.moveSpeed * enemy.FacingDirection);
    }

    protected override void DoChecks()
    {
        base.DoChecks();
        
        isGrounded = enemy.IsGroundDetected();
        isTouchingWall = enemy.IsWallDetected();
        isTouchingLedge = enemy.IsLedgeDetected();
    }
}
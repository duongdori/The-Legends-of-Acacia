using UnityEngine;

public class GoblinMoveState : GoblinGroundedState
{
    protected bool isMaxDetectedPlayer;
    protected bool isMinDetectedPlayer;


    public GoblinMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData, Enemy_Goblin enemy) : base(enemyBase, stateMachine, animBoolName, enemyData, enemy)
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

        
        // if (isMaxDetectedPlayer)
        // {
        //     stateMachine.ChangeState(enemyBase.DetectedState);
        // }
        // else if (isMinDetectedPlayer)
        // {
        //     stateMachine.ChangeState(enemyBase.AttackState);
        // }
        // else if (!isGrounded || isTouchingWall || isTouchingLedge)
        // {
        //     stateMachine.ChangeState(enemyBase.IdleState);
        // }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        enemy.SetVelocityX(enemyData.moveSpeed * enemy.FacingDirection);
    }

    protected override void DoChecks()
    {
        base.DoChecks();

        // isMaxDetectedPlayer = CheckMaxDetectedPlayer();
        // isMinDetectedPlayer = CheckMinDetectedPlayer();
        
        isGrounded = enemy.IsGroundDetected();
        isTouchingWall = enemy.IsWallDetected();
        isTouchingLedge = enemy.IsLedgeDetected();
    }
}
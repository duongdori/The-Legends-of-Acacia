using UnityEngine;

public class GoblinIdleState : GoblinGroundedState
{
    
    protected bool isMaxDetectedPlayer;
    protected bool isMinDetectedPlayer;


    public GoblinIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData, Enemy_Goblin enemy) : base(enemyBase, stateMachine, animBoolName, enemyData, enemy)
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



        // if (isMaxDetectedPlayer)
        // {
        //     stateMachine.ChangeState(enemy.DetectedState);
        // }
        // else if (isMinDetectedPlayer)
        // {
        //     stateMachine.ChangeState(enemy.AttackState);
        // }
        // else if (Time.time >= startTime + randomIdleTime)
        // {
        //     isIdleTimeOver = true;
        //     stateMachine.ChangeState(enemy.MoveState);
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
        isGrounded = enemy.IsGroundDetected();
        isTouchingWall = enemy.IsWallDetected();
        isTouchingLedge = enemy.IsLedgeDetected();
    }
    
    private float RandomIdleTime()
    {
        return Random.Range(enemyData.minIdleTime, enemyData.maxIdleTime);
    }
}
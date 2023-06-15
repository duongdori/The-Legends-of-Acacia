using UnityEngine;

public class EnemyDetectedPlayerState : EnemyState
{
    protected bool isMaxDetectedPlayer;
    protected bool isMinDetectedPlayer;


    public EnemyDetectedPlayerState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData) : base(enemyBase, stateMachine, animBoolName, enemyData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        // Debug.Log("Detected Player");
    }
    public override void Exit()
    {
        base.Exit();
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if(isExitingState) return;
        
        // if (!isMaxDetectedPlayer)
        // {
        //     stateMachine.ChangeState(enemyBase.IdleState);
        // }
        // else if (isMinDetectedPlayer && isGrounded)
        // {
        //     stateMachine.ChangeState(enemyBase.AttackState);
        // }
        
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        // enemyBase.SetVelocityX(enemyData.detectedMoveSpeed * enemyBase.FacingDirection);
    }
    protected override void DoChecks()
    {
        base.DoChecks();
        // isMaxDetectedPlayer = CheckMaxDetectedPlayer();
        // isMinDetectedPlayer = CheckMinDetectedPlayer();
    }
}
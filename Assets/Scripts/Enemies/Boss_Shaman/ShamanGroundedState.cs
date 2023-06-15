using UnityEngine;

public class ShamanGroundedState : EnemyState
{
    protected Boss_Shaman enemy;
    
    public ShamanGroundedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData, Boss_Shaman enemy) : base(enemyBase, stateMachine, animBoolName, enemyData)
    {
        this.enemy = enemy;
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
        
        if(isExitingState) return;
                
        if (enemy.IsPlayerDetected())
        {
            stateMachine.ChangeState(enemy.BattleState);
        }
        else if (enemy.IsPlayerDetectedBack())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.BattleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    protected override void DoChecks()
    {
        base.DoChecks();
    }
}
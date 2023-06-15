using UnityEngine;

public class EnemyDeathState : EnemyState
{
    public EnemyDeathState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData) : base(enemy, stateMachine, animBoolName, enemyData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyBase.SetColliderHeight(enemyData.deathColliderHeight);
        enemyBase.SetVelocityZero();
        // core.Combat.isdead = false;
    }
    public override void Exit()
    {
        base.Exit();
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if(!isExitingState) return;
        
        // enemyBase.DestroyEnemy();
        
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    protected override void DoChecks()
    {
        base.DoChecks();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        isExitingState = true;
    }
}
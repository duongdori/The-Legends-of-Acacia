using UnityEngine;

public class ShamanAttackState : EnemyState
{
    private Boss_Shaman enemy;
    private int attackCounter;

    public ShamanAttackState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData, Boss_Shaman enemy) : base(enemyBase, stateMachine, animBoolName, enemyData)
    {
        this.enemy = enemy;
    }
    
    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocityZero();

        enemy.Anim.SetInteger("attackCounter", 1);
    }

    public override void Exit()
    {
        base.Exit();
        lastTimeAttacked = Time.time;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        enemy.SetVelocityZero();

        if (isAnimationFinished)
        {
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

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}
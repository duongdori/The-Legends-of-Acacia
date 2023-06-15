using UnityEngine;

public class ShamanDeadState : EnemyState
{
    private Boss_Shaman enemy;


    public ShamanDeadState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData, Boss_Shaman enemy) : base(enemyBase, stateMachine, animBoolName, enemyData)
    {
        this.enemy = enemy;
    }
    
    public override void Enter()
    {
        base.Enter();
        AudioManager.Instance.PlaySFX(6);
        enemy.SetVelocityZero();
        enemy.InitializeEffect();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            enemy.DestroyEnemy();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}
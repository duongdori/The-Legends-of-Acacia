using UnityEngine;

public class GoblinBattleState : EnemyState
{
    private Enemy_Goblin enemy;
    private Transform player;

    private int moveDirection;
    
    public GoblinBattleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData, Enemy_Goblin enemy) : base(enemyBase, stateMachine, animBoolName, enemyData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = PlayerCtrl.Instance.Player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // if (enemy.IsPlayerDetected())
        // {
        //     stateTimer = enemyData.battleTime;
        //     if (enemy.IsPlayerDetected().distance <= enemyData.attackDistance)
        //     {
        //         if (CanAttack())
        //         {
        //             stateMachine.ChangeState(enemy.AttackState);
        //         }
        //     }
        // }
        // else
        // {
        //     if (stateTimer <= 0)
        //     {
        //         stateMachine.ChangeState(enemy.IdleState);
        //     }
        // }
        

        if (!enemy.IsGroundDetected() || enemy.IsWallDetected() || !enemy.IsPlayerDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.IdleState);
        }
        else
        {
            if (enemy.IsPlayerDetected().distance <= enemyData.attackDistance)
            {
                if (!CanAttack()) return;

                stateMachine.ChangeState(enemy.AttackState);
            }
            else
            {
                SetMoveDirection();
                enemy.SetVelocityX(enemyData.moveDetectedSpeed * moveDirection);
            }
            
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

    private void SetMoveDirection()
    {
        if (player.position.x > enemy.transform.position.x)
        {
            moveDirection = 1;
        }
        else if (player.position.x < enemy.transform.position.x)
        {
            moveDirection = -1;
        }
        enemy.CheckIfShouldFlip(moveDirection);

    }

    private bool CanAttack()
    {
        if (Time.time >= lastTimeAttacked + enemyData.attackCooldown)
        {
            lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }
}
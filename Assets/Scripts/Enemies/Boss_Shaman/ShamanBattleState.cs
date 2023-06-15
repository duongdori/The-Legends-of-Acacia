using UnityEngine;

public class ShamanBattleState : EnemyState
{
    private Boss_Shaman enemy;
    
    private Transform player;

    private int moveDirection;
    
    public ShamanBattleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData, Boss_Shaman enemy) : base(enemyBase, stateMachine, animBoolName, enemyData)
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

        if (IsAttack2Distance())
        {
            if (IsAttackDistance())
            {
                stateMachine.ChangeState(enemy.AttackState);
            }
            else
            {
                stateMachine.ChangeState(enemy.Attack2State);
            }
        }


        if (!enemy.IsGroundDetected() || enemy.IsWallDetected() || enemy.IsLedgeDetected() || !enemy.IsPlayerDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemy.SetVelocityX(enemyData.moveDetectedSpeed * enemy.FacingDirection);
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
        else if (Vector2.Distance(player.position, enemy.transform.position) <= 0.5)
        {
            Debug.Log("gdf");
            moveDirection = 1;
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
    
    public RaycastHit2D IsAttackDistance()
    {
        return Physics2D.Raycast(enemy.WallCheck.position, Vector2.right * enemy.FacingDirection, enemyData.attackDistance,
            enemyData.whatIsPlayer);
    }
    
    public RaycastHit2D IsAttack2Distance()
    {
        return Physics2D.Raycast(enemy.WallCheck.position, Vector2.right * enemy.FacingDirection, enemyData.attackDistance + 2f,
            enemyData.whatIsPlayer);
    }
}
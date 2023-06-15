using UnityEngine;

public class GoblinHurtState : EnemyState
{
        private Enemy_Goblin enemy;


        public GoblinHurtState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData, Enemy_Goblin enemy) : base(enemyBase, stateMachine, animBoolName, enemyData)
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
                
                if(!isAnimationFinished) return;
                
                stateMachine.ChangeState(enemy.IdleState);
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
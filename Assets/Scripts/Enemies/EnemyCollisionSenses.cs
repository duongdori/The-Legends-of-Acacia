using System;
using UnityEngine;

public class EnemyCollisionSenses : CollisionSenses
{
        [Header("Enemy Detect")]
        [SerializeField] private float maxDetectDistance;
        [SerializeField] private float minDetectDistance;
        
        [SerializeField] private LayerMask whatIsPlayer;

        public Vector2 player;
        

        public bool CheckMaxDetectRange()
        {
                RaycastHit2D hit = Physics2D.Raycast(WallCheck.position, Vector2.right * core.Movement.FacingDirection, maxDetectDistance, whatIsPlayer);
                
                RaycastHit2D hit1 = Physics2D.Raycast(WallCheck.position, Vector2.right * -core.Movement.FacingDirection, maxDetectDistance, whatIsPlayer);
                
                Debug.DrawRay(WallCheck.position, new Vector2(maxDetectDistance, 0f) * core.Movement.FacingDirection, Color.yellow);
                
                Debug.DrawRay(WallCheck.position, new Vector2(maxDetectDistance, 0f) * -core.Movement.FacingDirection, Color.yellow);

                player = hit.point;
                return hit.collider != null || hit1.collider != null;
        }
        
        public bool CheckMinDetectRange()
        {
                RaycastHit2D hit = Physics2D.Raycast(WallCheck.position, Vector2.right * core.Movement.FacingDirection, minDetectDistance, whatIsPlayer);
                
                Debug.DrawRay(WallCheck.position, new Vector2(minDetectDistance, 0f) * core.Movement.FacingDirection, Color.green);
                
                return hit.collider != null;
        }
}
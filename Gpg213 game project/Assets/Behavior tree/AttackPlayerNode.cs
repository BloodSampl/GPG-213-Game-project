using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class AttackPlayerNode : BTNode
    {
        private EnemyMover enemyMover;
        private PlayerMovement player;
        private float attackDistanceThreshold = 2f;

        public AttackPlayerNode(EnemyMover mover, PlayerMovement player)
        {
            enemyMover = mover;
            this.player = player;
        }

        public override NodeState Evaluate()
        {
            // Implement logic to attack the player
            // Example: Check if the player is in range and attack
            float distanceToPlayer = Vector3.Distance(enemyMover.transform.position, player.transform.position);

            if (distanceToPlayer <= attackDistanceThreshold)
            {
                Debug.Log("Hitting player");
                enemyMover.AttackPlayer(player);
                return NodeState.SUCCESS;
            }
            else
            {
                return NodeState.FAILURE;
            }
        }
    }
}


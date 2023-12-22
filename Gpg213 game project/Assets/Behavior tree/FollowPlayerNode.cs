using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class FollowPlayerNode : BTNode
    {
        private EnemyMover enemyMover;
        private PlayerMovement player;
        private float followDistanceThreshold = 5f;

        public FollowPlayerNode(EnemyMover mover, PlayerMovement player)
        {
            enemyMover = mover;
            this.player = player;
        }

        public override NodeState Evaluate()
        {
            // Implement logic to follow the player
            // Example: Move towards the player using pathfinding or simple navigation
            float distanceToPlayer = Vector3.Distance(enemyMover.transform.position, player.transform.position);

            if (distanceToPlayer <= followDistanceThreshold)
            {
                enemyMover.FollowPlayer(player.transform.position);
                return NodeState.SUCCESS;
            }
            else
            {
                return NodeState.FAILURE;
            }
        }
    }
}


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
           
            float distanceToPlayer = Vector3.Distance(enemyMover.transform.position, player.transform.position);

            if (distanceToPlayer <= followDistanceThreshold)
            {
                Debug.Log("following player");
               // enemyMover.FollowPlayer(player.transform.position);
                return NodeState.SUCCESS;
            }
            else
            {
                //Debug.Log("leave player");
                return NodeState.FAILURE;
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class FollowPathNode : BTNode
    {
        private EnemyMover enemyMover;
        private List<Vector3> predefinedPath;
        private int currentPathIndex;

        public FollowPathNode(EnemyMover mover, List<Vector3> path)
        {
            enemyMover = mover;
            predefinedPath = path;
            currentPathIndex = 0;
        }

        public override NodeState Evaluate()
        {
            // Implement logic to follow the predefined path
            // Example: Move towards the next point in the predefined path

            if (currentPathIndex < predefinedPath.Count)
            {
                Vector3 targetPosition = predefinedPath[currentPathIndex];

               // if (/*Logic to check if the enemy is close enough to the target position*/)
                {
                    enemyMover.MoveTowards(targetPosition);
                    currentPathIndex++;
                }

                return NodeState.RUNNING; // Continue following the path
            }
            else
            {
                return NodeState.SUCCESS; // Path reached its end
            }
        }
    }
}


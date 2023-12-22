using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class SelectorNode : BTNode
    {
        private FollowPlayerNode followPlayerNode;
        private AttackPlayerNode attackPlayerNode;
        private FollowPathNode followPathNode;

        public SelectorNode(FollowPlayerNode followNode, AttackPlayerNode attackNode, FollowPathNode pathNode)
        {
            followPlayerNode = followNode;
            attackPlayerNode = attackNode;
            followPathNode = pathNode;
        }

        public override NodeState Evaluate()
        {
            // Evaluate the follow, attack, and path nodes
            NodeState followState = followPlayerNode.Evaluate();
            NodeState attackState = attackPlayerNode.Evaluate();
            NodeState pathState = followPathNode.Evaluate();

            // Prioritize attacking over following
            if (attackState == NodeState.SUCCESS)
                return NodeState.SUCCESS;
            // Prioritize following the path over following the player
            else if (pathState == NodeState.SUCCESS)
                return NodeState.SUCCESS;
            else if (followState == NodeState.SUCCESS)
                return NodeState.SUCCESS;
            else
                return NodeState.FAILURE;
        }
    }
}


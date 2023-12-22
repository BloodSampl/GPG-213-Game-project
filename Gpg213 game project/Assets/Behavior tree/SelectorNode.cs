using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class SelectorNode : BTNode
    {
        private FollowPlayerNode followPlayerNode;
        private AttackPlayerNode attackPlayerNode;

        public SelectorNode(FollowPlayerNode followNode, AttackPlayerNode attackNode)
        {
            followPlayerNode = followNode;
            attackPlayerNode = attackNode;
        }

        public override NodeState Evaluate()
        {
            // Evaluate the follow, attack, and path nodes
            NodeState followState = followPlayerNode.Evaluate();
            NodeState attackState = attackPlayerNode.Evaluate();

            if (attackState == NodeState.SUCCESS)
                return NodeState.SUCCESS;                   
            if (followState == NodeState.SUCCESS)
                return NodeState.SUCCESS;
            else
                return NodeState.FAILURE;
        }
    }
}


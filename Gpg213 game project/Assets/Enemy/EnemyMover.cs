using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    bool enemyMovingTowrdsGoal;
    PathFindingCalculations pathF;
    List<Node> enemyPath = new List<Node>();
    [SerializeField]
    [Range(0f,5f)] public float speed = 1f;
    private BTNode behaviorTreeRoot;
    public PlayerMovement player;
    bool followingPlayer;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        pathF = FindObjectOfType<PathFindingCalculations>();
        // Create instances of FollowPlayerNode, AttackPlayerNode, and FollowPathNode
        FollowPlayerNode followNode = new FollowPlayerNode(this, player);
        AttackPlayerNode attackNode = new AttackPlayerNode(this, player);
        

        // Create the behavior tree root node (now named SelectorNode)
        behaviorTreeRoot = new SelectorNode(followNode, attackNode);
    }
    private void Update()
    {
        behaviorTreeRoot.Evaluate();
        if (pathF != null && !enemyMovingTowrdsGoal)
        {
            enemyPath = new List<Node>(pathF.enemyPath);
            enemyPath.Reverse();
            if (enemyPath.Count > 0)
            {
                StartCoroutine(EnemyPathFinder());
                enemyMovingTowrdsGoal = true;
            }
        }
    }
    public void FollowPlayer(Vector3 targetPosition)
    {
        // Implement your movement logic here
        // Example: Move towards the target position
            followingPlayer = true;
            StopCoroutine(EnemyPathFinder());
            Debug.Log("Following player to: " + targetPosition);
            transform.LookAt(targetPosition);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition,step);
            
        
    }
    public void AttackPlayer(PlayerMovement targetPlayer)
    {
        

        Debug.Log("Attacking player: " + targetPlayer.name);
        
    }
    IEnumerator EnemyPathFinder()
    {
        foreach (Node node in enemyPath)
        {
            string nodeName = node.NodeGridPos.ToString();
            GameObject nodeObject = GameObject.Find(nodeName);

            if (nodeObject != null)
            {
                //Debug.Log(nodeObject.transform.position);
                Vector3 startPostion = transform.position;
                Vector3 endPostion = nodeObject.transform.position;
                float travelTime = 0f;

                transform.LookAt(endPostion);
                while(travelTime < 1f)
                {
                    travelTime += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startPostion, endPostion, travelTime);
                    yield return new WaitForEndOfFrame();
                    if (followingPlayer)
                    {
                        break;
                    }
                }
                followingPlayer = false;
            }
        }
    }
}
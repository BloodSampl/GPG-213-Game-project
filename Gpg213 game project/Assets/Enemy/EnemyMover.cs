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
    float followDistanceThreshold = 5f;
    

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        pathF = FindObjectOfType<PathFindingCalculations>();

        FollowPlayerNode followNode = new FollowPlayerNode(this, player);
        AttackPlayerNode attackNode = new AttackPlayerNode(this, player);
        


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
                StopCoroutine(EnemyPathFinder());
                StartCoroutine(EnemyPathFinder());
                enemyMovingTowrdsGoal = true;
            }
        }
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > followDistanceThreshold && followingPlayer)
        {
            StopCoroutine(EnemyPathFinder());
            pathF.makeNewPath = true;
            followingPlayer = false;
            pathF.FindPath(FindCurrentGridPosition(), pathF.endNode);
            FindCurrentGridPosition();
            StartCoroutine(EnemyPathFinder());
            pathF.makeNewPath = false;
            pathF.pathFind = true;
        }
    }
    public Vector2Int FindCurrentGridPosition()
    {

        float sphereRadius = 0.5f;

        RaycastHit hit;

        if (Physics.SphereCast(transform.position, sphereRadius, Vector3.forward, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {

            string objectName = hit.collider.gameObject.name;

            string[] coordinates = objectName.Trim('(', ')').Split(',');
            int x, y;

            if (coordinates.Length == 2 && int.TryParse(coordinates[0], out x) && int.TryParse(coordinates[1], out y))
            {
                Vector2Int gridPos = new Vector2Int(x, y);
                return gridPos;
            }
            else
            {
                Debug.LogError("Invalid object name format: " + objectName);
            }
        }


        return Vector2Int.zero;
    }

   /* public void FollowPlayer(Vector3 targetPosition)
    {

         followingPlayer = true;
         StopCoroutine(EnemyPathFinder());
         Debug.Log("Following player to: " + targetPosition);
         transform.LookAt(targetPosition);
         float step = speed * Time.deltaTime;
         transform.position = Vector3.MoveTowards(transform.position, targetPosition,step);         
    }*/
    public void AttackPlayer(PlayerMovement targetPlayer)
    {
        Debug.Log("Attacking player: " + targetPlayer.name);    
    }
    IEnumerator EnemyPathFinder()
    {
        foreach (Node node in enemyPath)
        {
            if (followingPlayer)
            {
                break;
            }
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
                
            }
        }
    }
}
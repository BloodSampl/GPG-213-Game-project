using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    bool enemyMovingTowrdsGoal;
    PathFindingCalculations pathF;
    List<Node> enemyPath = new List<Node>();
    [SerializeField]
    float speed;

    private void Start()
    {
        pathF = FindObjectOfType<PathFindingCalculations>();
    }
    private void Update()
    {
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
    // seperate path finding from the enemy
    // when I move the cube or somthing happens I will get a new pathfor the enemy
    IEnumerator EnemyPathFinder()
    {
        foreach (Node node in enemyPath)
        {
            string nodeName = node.NodeGridPos.ToString();
            GameObject nodeObject = GameObject.Find(nodeName);

            if (nodeObject != null)
            {
                Vector3 startPostion = transform.position;
                Vector3 endPostion = nodeObject.transform.position;
                float travelTime = 0f;

                transform.LookAt(endPostion);
                while(travelTime < 1f)
                {
                    travelTime += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startPostion, endPostion, travelTime);
                    yield return new WaitForEndOfFrame();
                }
            }
        }
        Destroy(gameObject);
    }
}
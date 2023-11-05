using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    PathFindingCalculations pathF;
    [SerializeField] List<Node> enemyPath = new List<Node>();
    private void Start()
    {
        pathF = FindAnyObjectByType<PathFindingCalculations>().GetComponent<PathFindingCalculations>();
        if(pathF != null )
        {
            enemyPath = pathF.enemyPath;
            enemyPath.Reverse();
            StartCoroutine(EnemyPathFinder());
        }
    }
    void Update()
    {
        //GetEnemyPath();
        // transform.position = enemyPath[0].transform.position;
    }
    IEnumerator EnemyPathFinder()
    { 
        foreach (Node node in enemyPath)
        {
            GameObject nodeObject = GameObject.Find(node.NodeGridPos.ToString());
            Debug.Log(nodeObject.transform.position);
            transform.position = nodeObject.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}

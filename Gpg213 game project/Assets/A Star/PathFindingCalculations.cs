
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//[ExecuteAlways]
public class PathFindingCalculations : MonoBehaviour
{
    PathFindingGrid grid;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] Vector2Int startingNode; //30 ,0
    [SerializeField] public Vector2Int endNode;  //30 ,84
    [SerializeField] Vector2Int secondStartingNode; //60 ,20
    [SerializeField] Vector2Int thirdStartingNode;//  5,84
    public List<Node> enemyPath = new List<Node>();
    List<Node> openNodes = new List<Node>();
    List<Node> closedNodes = new List<Node>();

    public int wave = 1;
    public bool pathFind = true;
    public bool makeNewPath;


    private void Awake()
    {
        grid = GetComponent<PathFindingGrid>();
    }
    private void Start()
    {
        grid.GenerateGrid();
        ChangeColorsForOpenNodes(Color.green);
       // FindPath();
    }
    private void Update()
    {
        if (wave== 1 && pathFind && !makeNewPath)
        {
            FindPath(startingNode, endNode);
            pathFind = false;
            
        }
        if (wave == 2 && pathFind && !makeNewPath)
        {
            FindPath(secondStartingNode, endNode);
            pathFind = false;

        }
        if (wave == 3 && pathFind && !makeNewPath)
        {
            FindPath(thirdStartingNode, endNode);
            pathFind = false;
        }
    }
    public void FindPath(Vector2Int startingNode, Vector2Int endNode)
    {
        Node startNode = grid.GetNode(startingNode);
        Node targetNode = grid.GetNode(endNode);
        startNode.Reset();
        targetNode.Reset();

        openNodes.Clear();  // Clear openNodes list
        closedNodes.Clear();  // Clear closedNodes list
                              // Clear the old path and reset the color of nodes in the old path
        foreach (Node node in enemyPath)
        {
            GameObject oldNodeObject = GameObject.Find(node.NodeGridPos.ToString());
            Renderer oldNodeRenderer = oldNodeObject.GetComponentInChildren<Renderer>();
            oldNodeRenderer.material.color = Color.white; // Set the color to the default color or any color you prefer
        }

        // Create a new enemyPath list
        enemyPath = new List<Node>();
        openNodes.Add(startNode);

        while (openNodes.Count > 0)
        {
            Node currentNode = GetLowestFcostNode(openNodes);

            if(currentNode == targetNode)
            {
                enemyPath = RetracePath(startNode, targetNode);
                Debug.Log("Path Found");
                return; 
            }
            openNodes.Remove(currentNode);
            closedNodes.Add(currentNode);


            foreach(Node neighbor in GetNeighbors(currentNode))
            {
                if(!neighbor.Walkble || closedNodes.Contains(neighbor))
                {
                    continue;
                }
                //neighbor.Reset();
                int newNeighborGcost = currentNode.Gcost + CalculateNodeCost(currentNode.NodeGridPos, neighbor.NodeGridPos);

                if(newNeighborGcost < neighbor.Gcost || !openNodes.Contains(neighbor))
                {
                    neighbor.Gcost = newNeighborGcost;
                    
                    neighbor.Hcost = CalculateNodeCost(neighbor.NodeGridPos, endNode);
                    
                    neighbor.Parent = currentNode;

                    if(!openNodes.Contains(neighbor))
                    {
                        openNodes.Add(neighbor);
                    }
                }
            }
        }
        Debug.Log("No Path was found");
    }
    Node GetLowestFcostNode(List<Node> nodes)
    {
        Node lowestFcostNode = nodes[0];
        for(int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].Fcost < lowestFcostNode.Fcost)
            {
                lowestFcostNode = nodes[i];
            }
        }
        return lowestFcostNode;
    }
    List<Node> GetNeighbors(Node current)
    {
        List<Node> neighborNodes = new List<Node>();

        Vector2Int currentPosition = current.NodeGridPos;

        LayerMask obstacleLayer = LayerMask.GetMask("ObstacleLayer");

        float sphereRadius = 0.5f;

        if (currentPosition.x < grid.width - 1)
        {
            Vector2Int rightNeighborPos = currentPosition + new Vector2Int(1, 0);
            if (IsNodeWalkable(currentPosition, rightNeighborPos, obstacleLayer, sphereRadius))
            {
                neighborNodes.Add(grid.GetNode(rightNeighborPos));
            }
        }
        if (currentPosition.x > 0)
        {
            Vector2Int leftNeighborPos = currentPosition + new Vector2Int(-1, 0);
            if (IsNodeWalkable(currentPosition, leftNeighborPos, obstacleLayer, sphereRadius))
            {
                neighborNodes.Add(grid.GetNode(leftNeighborPos));
            }
        }
        if (currentPosition.y < grid.height - 1)
        {
            Vector2Int topNeighborPos = currentPosition + new Vector2Int(0, 1);
            if (IsNodeWalkable(currentPosition, topNeighborPos, obstacleLayer, sphereRadius))
            {
                neighborNodes.Add(grid.GetNode(topNeighborPos));
            }
        }
        if (currentPosition.y > 0)
        {
            Vector2Int bottomNeighborPos = currentPosition + new Vector2Int(0, -1);
            if (IsNodeWalkable(currentPosition, bottomNeighborPos, obstacleLayer, sphereRadius))
            {
                neighborNodes.Add(grid.GetNode(bottomNeighborPos));
            }
        }
        return neighborNodes;
    }
    bool IsNodeWalkable(Vector2Int from, Vector2Int to, LayerMask obstacleLayer, float radius)
    {
        Node fromNode = grid.GetNode(from);
        Node toNode = grid.GetNode(to);

        // Check if the node is walkable using sphere detection
        if (fromNode.IsWalkableTo(toNode, obstacleLayer, radius))
        {
            return true;
        }
        return false;
    }
    int CalculateNodeCost(Vector2Int nodOneVector, Vector2Int nodTwoVector)
    {
        return Mathf.Abs(nodOneVector.x - nodTwoVector.x) +
                Mathf.Abs(nodOneVector.y - nodTwoVector.y);
    }
    void ChangeColorsForOpenNodes(Color color)
    {
        foreach (Node node in openNodes)
        {
            GameObject nodeObject = GameObject.Find(node.NodeGridPos.ToString());
            Renderer nodeRenderer = nodeObject.GetComponentInChildren<Renderer>();
            nodeRenderer.material.color = color;
        }
    }
     public List<Node> RetracePath(Node start, Node goal)
    {
        List<Node> path = new List<Node>();
        Node currentNode = goal;

        while (currentNode != start)
        {
            path.Add(currentNode);
            currentNode = currentNode.Parent;
        }
        DisplayPath(path);
        return  path;
    }
    void DisplayPath(List<Node> path)
    {
        foreach(Node node in path)
        {
            GameObject nodeObject = GameObject.Find(node.NodeGridPos.ToString());
            Renderer nodeRenderer = nodeObject.GetComponentInChildren<Renderer>();
            nodeRenderer.material.color = Color.blue;
        }
    }
}

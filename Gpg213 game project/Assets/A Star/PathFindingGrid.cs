using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//[ExecuteAlways]
public class PathFindingGrid : MonoBehaviour
{
    PathFindingCalculations calculations;
    public int width;
    public int height;
    [SerializeField] List<Node> nodes = new List<Node>();
    public GameObject prefab;
    GameObject nodPrefab;

    private void Start()
    {
        //GenerateGrid();
    }
    public Node GetNode(Vector2Int gridPosition)
    {
        int index = gridPosition.x + gridPosition.y * width;
        return nodes[index];
    }

    public void GenerateGrid()
    {
        Transform gridParent = transform;
        for (int z = 0; z < height; z++)
        {
            for(int x = 0; x < width; x++)
            {
                Vector2Int pos = new Vector2Int(x, z);
                Vector3 nodeWorldPos = gridParent.position + new Vector3(pos.x, 0, pos.y);

                Node newNode = new Node(pos, nodeWorldPos);
                nodPrefab = Instantiate(prefab, nodeWorldPos, Quaternion.identity);
                newNode.go = nodPrefab;
                nodPrefab.transform.parent = gridParent;
                nodPrefab.name = pos.ToString();
                nodes.Add(newNode);
            }
        }
    }

}

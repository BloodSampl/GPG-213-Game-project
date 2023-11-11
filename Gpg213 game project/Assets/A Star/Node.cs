using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/*public enum GroundType
{
    Default,
    WalkableGround,
    // Add more ground types as needed
}*/
public class Node
{
    public GameObject go;

    public int Hcost;
    public int Gcost;
    public int Fcost
    {
        get
        {         
            return Hcost + Gcost;
        }
    }
    public TextMeshProUGUI Lable
    {
        get
        {
            return go.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        }
        set
        {
            Lable = value;
        }
    }
    //public GroundType Ground { get; set; } = GroundType.Default;

    public bool Walkble = true;
    public Node Parent; 
    public Vector2Int NodeGridPos;
    public Vector3 NodeWorldPos;

    public Node(Vector2Int nodePos, Vector3 nodeWorldPos)
    {
        NodeGridPos = nodePos;
        NodeWorldPos = nodeWorldPos;
    }
    public bool IsWalkableTo(Node targetNode, LayerMask obstacleLayer, float radius)
    {
        Vector3 fromPosition = NodeWorldPos;
        Vector3 toPosition = targetNode.NodeWorldPos;

        // Check if there's any collider within the sphere
        if (Physics.CheckSphere(fromPosition, radius, obstacleLayer))
        {
            // If the sphere hits an obstacle, the node is not walkable
            return false;
        }

        // The node is walkable if the sphere doesn't hit any obstacles
        return true;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
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
    public void Reset()
    {
        Gcost = 0;
        Hcost = 0;
        Parent = null;
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

        if (Physics.CheckSphere(fromPosition, radius, obstacleLayer))
        {
            return false;
        }
        return true;
    }
}

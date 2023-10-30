using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Node //: IComparable
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
        
        

    public bool Walkble = true;
    public Node Parent; 
    public Vector2Int NodeGridPos;
    public Vector3 NodeWorldPos;

    public Node(Vector2Int nodePos, Vector3 nodeWorldPos)
    {
        NodeGridPos = nodePos;
        NodeWorldPos = nodeWorldPos;
    }

    //public int CompareTo(object obj)
    //{
    //    Node otherNode = (Node)obj;
    //
    //    if(Fcost < otherNode.Fcost)
    //    {
    //
    //    }
    //}
}

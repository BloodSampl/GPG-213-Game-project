using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceSelector : MonoBehaviour
{
    [SerializeField] public List<GameObject> deffences = new List<GameObject>();
    public int defenceSelection;
    //[HideInInspector] public GameObject go;

    public void selection1()
    {
        defenceSelection = 0;
        InstantiatingDefence();
        
    }
    public void selection2()
    {
        defenceSelection = 1;
        InstantiatingDefence();
        
    }
    public void selection3()
    {
        defenceSelection = 2;
        InstantiatingDefence();
        
    }
    public void InstantiatingDefence()
    {
        GameObject go = Instantiate(deffences[defenceSelection]);
        Renderer [] renderer = go.GetComponentsInChildren<Renderer>();
        foreach(Renderer renderer2 in renderer)
        {
             renderer2.material.color = Color.blue;
        }
    }
}

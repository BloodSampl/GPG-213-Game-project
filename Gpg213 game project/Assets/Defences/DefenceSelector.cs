using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceSelector : MonoBehaviour
{
    [SerializeField] public List<GameObject> deffences = new List<GameObject>();
    Currency currency;
    public int defenceSelection;

    int bearTrapPrice = 3;
    int spikeRollPrice = 5;
    int spikeFloorPrice = 4;

    //[HideInInspector] public GameObject go;

    public void selection1()
    {
        if(currency.currentGold >= bearTrapPrice)
        {
            defenceSelection = 0;
            InstantiatingDefence();
        }   
    }
    public void selection2()
    {
        if (currency.currentGold >= spikeRollPrice)
        {
            defenceSelection = 1;
            InstantiatingDefence();
        }      
    }
    public void selection3()
    {
        if (currency.currentGold >= spikeFloorPrice)
        {
            defenceSelection = 2;
            InstantiatingDefence();
        }
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

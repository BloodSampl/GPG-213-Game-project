using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public int goldThreshhold;
    public int currentGold = 0;

    public int goldIncrease;

    private void Start()
    {
        text.text = currentGold.ToString();
    }
    public int GoldIncrease(int goldIncrease)
    {
        return currentGold = goldIncrease;
    }

}

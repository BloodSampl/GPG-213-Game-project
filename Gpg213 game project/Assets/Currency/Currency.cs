using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    public int goldThreshhold;
    public int currentGold = 0;

    public int goldIncrease;
    public int GoldIncrease(int goldIncrease)
    {
        return currentGold = goldIncrease;
    }

}

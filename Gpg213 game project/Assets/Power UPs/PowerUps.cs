using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] Currency currency;
    [SerializeField] TextMeshProUGUI currencyText;
    [SerializeField] int powerUpPrice = 6;
    public void SlowDown()
    {
        if(currency.currentGold >= powerUpPrice)
        {
            EnemyMover[] enemies = FindObjectsOfType<EnemyMover>();
            foreach (EnemyMover enemy in enemies)
            {
                enemy.speed -= 1;
            }
            currency.currentGold -= powerUpPrice;
            currencyText.text = currency.currentGold.ToString();
        }
    }
}

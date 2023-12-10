using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyText;
    [SerializeField] EnemySO enemy;
    [SerializeField] Currency currency;
    EnemyUI enemyUI;
    
    float enemyMaxHealth;
    float enemyCurrentHealth;

    private void Start()
    {
        enemyUI = GetComponentInChildren<EnemyUI>();
        enemyMaxHealth = enemy.health;
        enemyCurrentHealth = enemyMaxHealth;
    }
    private void Update()
    {
        
    }
    void EnemyDamage(int damage)
    {
        if(enemyCurrentHealth > 0)
        {
            enemyCurrentHealth -= damage;
        }
        else
        {
            currency.GoldIncrease(5);
            Debug.Log("Enemy Is dead");
            Destroy(gameObject);
            currencyText.text = currency.currentGold.ToString();
        }
    }
    public void EnemyHit(int damage)
    {

         Debug.Log("ouch");
         EnemyDamage(damage);
         enemyUI.EnemyHealthBar(enemyCurrentHealth, enemyMaxHealth);
        
    }
}

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
    [SerializeField] EnemySpawner spawner;
    EnemyUI enemyUI;
    
    float enemyMaxHealth;
    float enemyCurrentHealth;

    private void Start()
    {
        currency = FindObjectOfType<Currency>().GetComponent<Currency>();
        currencyText = GameObject.Find("Canvas/GamePlay/Coins Board/Coins").GetComponent<TextMeshProUGUI>();
        enemyUI = GetComponentInChildren<EnemyUI>();
        spawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();
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
            Destroy(gameObject);
            spawner.enemiesNumber--;
            spawner.enemiesText.text = "Enemies: " + spawner.enemiesNumber.ToString();
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

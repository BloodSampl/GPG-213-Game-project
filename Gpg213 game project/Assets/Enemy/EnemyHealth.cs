using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] EnemySO enemy;
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
            Debug.Log("Enemy Is dead");
        }
    }
    public void EnemyHit()
    {

         Debug.Log("ouch");
         EnemyDamage(5);
         enemyUI.EnemyHealthBar(enemyCurrentHealth, enemyMaxHealth);
        
    }
}

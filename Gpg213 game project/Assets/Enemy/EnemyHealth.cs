using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] EnemySO enemy;
    [SerializeField] Image healthBar;
    float enemyMaxHealth;
    float enemyCurrentHealth;

    private void Start()
    {
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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player Weapon"))
        {
            Debug.Log("ouch");
            EnemyDamage(8);
            EnemyHealthBar(enemyCurrentHealth, enemyMaxHealth);
            Debug.Log(healthBar.transform.localScale.x.ToString());
        }
    }
    void EnemyHealthBar(float currentHealth , float maxHealth)
    {
        healthBar.transform.localScale = new Vector3(Mathf.Clamp(currentHealth/maxHealth, 0, 1), 1, 1); 
    }
}

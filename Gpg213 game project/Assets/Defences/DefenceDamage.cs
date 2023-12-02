using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceDamage : MonoBehaviour
{
    [SerializeField] int damage;
    EnemyHealth enemyHealth;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyHealth = other.GetComponent<EnemyHealth>();
            enemyHealth.EnemyHit(damage);
        }
    }
}

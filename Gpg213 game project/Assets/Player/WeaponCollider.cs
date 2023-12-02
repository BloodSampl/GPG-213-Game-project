using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    EnemyHealth enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy = FindAnyObjectByType(typeof(EnemyHealth)).GetComponent<EnemyHealth>();
            enemy.EnemyHit(5);
        }
    }
}

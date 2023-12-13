using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] int health = 15;
    //[SerializeField] int maxHealth;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            health -= 5;
        }
        if(health <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] EnemySpawner spawner;
    [SerializeField] int health = 15;
    [SerializeField] int maxHealth = 20;
    [SerializeField] TextMeshProUGUI baseHelthText;
    //[SerializeField] int maxHealth;
    private void Start()
    {
        baseHelthText.text = "Base " + health.ToString() + " / " + maxHealth.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            spawner.enemiesNumber--;
            spawner.enemiesText.text = "Enimies: " + spawner.enemiesNumber.ToString();
            health -= 1;
            baseHelthText.text = "Base " + health.ToString() + " / " + maxHealth.ToString();
        }
        if(health <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}

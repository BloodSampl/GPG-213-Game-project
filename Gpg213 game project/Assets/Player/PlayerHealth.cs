using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [Range(0f, 100f)]
    [SerializeField] float currentHealth;
    [SerializeField] Image healthBar;

    private void Update()
    {
        PlayerHealthUIScale(currentHealth, maxHealth);
    }

    void PlayerDamage(float damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
        }
        else
        {
            Debug.Log("You Are Dead");
        }
    }
    private void OnCollisionEnter(Collision collision) //  not working for some reason.
    {  
            Debug.Log("am hit");
            PlayerDamage(20);           
    }

    void PlayerHealthUIScale(float currentHeatlh, float maxHealth)
    {
        healthBar.transform.localScale = new Vector3(Mathf.Clamp(currentHeatlh/maxHealth, 0f, 1f),1,1);
    }
}

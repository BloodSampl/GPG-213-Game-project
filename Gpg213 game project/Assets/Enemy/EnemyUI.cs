using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{

    Image healthBar;
    private void Start()
    {
        healthBar = GetComponentInChildren<Image>();
    }
    public void EnemyHealthBar(float currentHealth, float maxHealth)
    {
        healthBar.transform.localScale = new Vector3(Mathf.Clamp(currentHealth / maxHealth, 0, 1), 1, 1);
    }
}

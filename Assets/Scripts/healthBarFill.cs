using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarFill : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;
    public float currentHealth;
    

    


    void Start()
    {
        currentHealth = maxHealth;
        SetHealth(currentHealth, maxHealth);
        
    }
    public void SetHealth(float health, float maxHealth)
    {
        healthBar.fillAmount = health / maxHealth;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        SetHealth(currentHealth, maxHealth);
    }
    
    
}

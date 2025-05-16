using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // REQUIRED for Slider

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float maxShield = 50f;
    public float currentHealth;
    public float currentShield;

    [Header("UI Sliders")]
    public Slider healthBar;
    public Slider shieldBar;

    void Start()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;

        if (healthBar != null)
            healthBar.maxValue = maxHealth;

        if (shieldBar != null)
            shieldBar.maxValue = maxShield;

        UpdateUI();
    }

    void UpdateUI()
    {
        if (healthBar != null)
            healthBar.value = currentHealth;

        if (shieldBar != null)
            shieldBar.value = currentShield;
      
    }

    public void TakeDamage(float damage)
    {
        if (currentShield > 0)
        {
            float shieldDamage = Mathf.Min(damage * 0.8f, currentShield);
            currentShield -= shieldDamage;
            currentHealth -= damage * 0.2f;
        }
        else
        {
            currentHealth -= damage;
        }

        currentHealth = Mathf.Max(0f, currentHealth);
        currentShield = Mathf.Max(0f, currentShield);

        UpdateUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        UnityEngine.Debug.Log("Player died!");
        SceneManager.LoadScene("GameOver"); // Or your actual game over scene name
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20f);
        }
    }

}

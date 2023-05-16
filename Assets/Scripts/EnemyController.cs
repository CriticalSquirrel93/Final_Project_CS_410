using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    public float initSpeed = 5f;

    [HideInInspector]
    public float speed;

    public float initHealth;
    private float _currentHealth;
    private bool _isDead;

    public int currencyWorth;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial values
        speed = initSpeed;
        _currentHealth = initHealth;
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;

        //healthBar.fillAmount = _currentHealth / initHealth;

        if (_currentHealth <= 0 && !_isDead)
        {
            Die();
        }
    }
    
    // Slow enemy by percentage
    public void Slow(float pct)
    {
        speed = initSpeed * (1f - pct);
    }
    
    // Process enemy death
    private void Die()
    {
        _isDead = true;

        PlayerStats.Money += currencyWorth;
        
        WaveSpawner.EnemiesAlive--;
        
        Destroy(gameObject);
    }
}

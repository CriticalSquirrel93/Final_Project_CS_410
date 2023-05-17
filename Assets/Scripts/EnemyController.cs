using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    public float initSpeed = 5f;
    
    [HideInInspector]
    public float speed;

    // Init values & other stats
    public float initHealth;
    public int damageAmount;
    private float _currentHealth;
    public int currencyWorth;
    
    // Navigation
    private NavMeshAgent agent;

    // UI
    public Image healthBar;

    // Death management
    private bool _isDead;
    private GameObject _pointOfExit;
    private Transform goal;
    [SerializeField] private AudioSource deathSfx;
    


    // Start is called before the first frame update
    void Start()
    {
        // Set initial values
        speed = initSpeed;
        _currentHealth = initHealth;
        _pointOfExit = GameObject.FindGameObjectWithTag("EnemySpawn");
    }

    void FixedUpdate() {
        
        GameObject[] crops = GameObject.FindGameObjectsWithTag("Crop");
        float shortestDistance = Mathf.Infinity;
        GameObject closest = null;
        agent = GetComponent<NavMeshAgent>();

        foreach (GameObject crop in crops)
        {
            float distance = Vector3.Distance(transform.position, crop.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closest = crop;
                goal = closest.transform;
            }
        }
        if (goal != null)
        {
            agent.destination = goal.transform.position;
        }
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
        // Flag as dead
        _isDead = true;
        
        // credit player money and reduce total enemy count.
        PlayerStats.Money += currencyWorth;
        WaveSpawner.EnemiesAlive--;
        
        // Play sfx and delete instance of enemy
        deathSfx.Play();
        Destroy(gameObject);
    }
    
    public void DieWithNoMoney()
    {
        // Flag as dead
        _isDead = true;
        // Reduce total enemy count
        WaveSpawner.EnemiesAlive--;
        // Delete enemy with no sfx.
        deathSfx.Play();
        Destroy(gameObject);
    }
}

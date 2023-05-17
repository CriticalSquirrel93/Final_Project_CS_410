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
    [SerializeField]
    


    [HideInInspector]
    public float speed;

    public float initHealth;
    public int damageAmount;
    private float _currentHealth;
    
    private bool _isDead;

    public int currencyWorth;

    public Image healthBar;

    private GameObject _pointOfExit;

    private Transform goal;

    private NavMeshAgent agent;

    


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
        _isDead = true;

        PlayerStats.Money += currencyWorth;
        
        WaveSpawner.EnemiesAlive--;
        
        Destroy(gameObject);
    }
    
    public void DieWithNoMoney()
    {
        _isDead = true;

        WaveSpawner.EnemiesAlive--;
        
        Destroy(gameObject);
    }
}

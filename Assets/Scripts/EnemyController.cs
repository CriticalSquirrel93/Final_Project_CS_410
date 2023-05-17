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

        GameObject[] crops = GameObject.FindGameObjectsWithTag("Crop");
        float shortestDistance = Mathf.Infinity;
        GameObject closest;

        for (var i = 0; i<crops.Length; i++) {
            float distance = Vector3.Distance(transform.position, crops[i].transform.position);
            if (distance < shortestDistance) {
                shortestDistance = distance;
                closest = crops[i];
            }
        }

        //https://itnext.io/it-follows-creating-zombie-enemies-in-unity-part-3-of-unity-gamedev-series-988da87c8273
        //pathfinder = GetComponent<Pathfinder>();
        //target = GameObject.Find("");

    }

    void Update() {
        // pathfinder.SetDestination(target.position)

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

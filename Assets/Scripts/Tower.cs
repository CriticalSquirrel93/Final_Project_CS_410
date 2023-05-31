using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private Transform target;
    private EnemyController targetEnemy;
    [SerializeField] public int TowerCost;

    public float range = 15f;
    
    [Header("Shared")]
    
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;

    [Header("Use Ice")] 
    
    public bool useIce = false;
    public GameObject icePrefab;
    public float fireRate = 1f;
    private float _fireCountdown = 0f;

    [Header("Use Fire")] 
    
    public bool useFire = false;
    public GameObject firePrefab;
    public int damageOverTime = 30;
    public float amount;
    
    [Header("Use Laser")] 
    
    public bool useLaser = false;
    public int damage = 9;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }

            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = 1f / fireRate;
            }

            _fireCountdown -= Time.deltaTime;
        }
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDist = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            // Get the distance to the currently selected enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            
            // If that enemy is closer than the previously checked enemy
            if (distanceToEnemy < shortestDist)
            {
                // Swap to targeting that enemy.
                shortestDist = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // As long as we have an enemy, and it is within range
        if (nearestEnemy != null && shortestDist <= range)
        {
            // Terget it, and grab it's controller script for damage processing
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<EnemyController>();
        }
        else
        {
            // Otherwise wait for the above to be true.
            target = null;
        }
    }

    private void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    private void Fire()
    {
        throw new NotImplementedException();
    }

    private void Ice()
    {
        throw new NotImplementedException();
    }

    private void Shoot()
    {
        throw new NotImplementedException();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range * transform.lossyScale.y);
    }
}

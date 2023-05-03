using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent enemy;
    private Transform goalPos;

    [SerializeField] public GameObject enemyGoal;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyGoal = GameObject.FindGameObjectWithTag("Goal");
        goalPos = enemyGoal.transform;
        enemy.SetDestination(goalPos.position);
    }

    // Update is called once per frame
    void Update()
    {
        //enemy.SetDestination();
        
    }
}

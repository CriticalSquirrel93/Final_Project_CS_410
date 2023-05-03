using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent enemy;
    private Transform goalPos;
    public int hp;

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

    void hit() {
        hp = hp - 1;
        if (hp <= 0) {
            Destroy(this.gameObject);
        }
    }
}

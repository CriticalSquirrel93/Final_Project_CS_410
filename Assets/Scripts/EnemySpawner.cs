using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject ratEnemyPrefab;

    [SerializeField] private float ratInterval = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        StartCoroutine(spawnEnemy(ratInterval, ratEnemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy,
            new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}

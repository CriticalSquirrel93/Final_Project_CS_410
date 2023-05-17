using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

// Shamelessly based on to a fair extent, Brackeys How to make a Tower Defense Game series from youtube
// Link : https://www.youtube.com/playlist?list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0
// Tried to do this several times on my own, and due to time, desperately needed a temporary and editable alternative.

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    private List<GameObject> _spawners = new List<GameObject>();

    public float timeBetweenWaves = 5f;
    private float _countdown = 2f;

    [SerializeField]
    private TextMeshProUGUI _waveCountdownText;
    
    private int _waveIndex = 0;

    private void Start()
    {
        foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("EnemySpawn"))
        {
            //Debug.Log("Adding spawner @ x : " + spawner.GetComponent<Tile>().GetCartesianXPos()  + ", y: " + spawner.GetComponent<Tile>().GetCartesianYPos() + " to the list");
            _spawners.Add(spawner);
        }
    }

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (_waveIndex == waves.Length)
        {
            this.enabled = false;
        }

        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
            return;
        }

        _countdown -= Time.deltaTime;

        _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);

        _waveCountdownText.text = string.Format("{0:00.00}", _countdown);
    }


    IEnumerator SpawnWave()
    {
        PlayerStats.WavesSurvived++;

        Wave wave = waves[_waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        _waveIndex++;
    }

    GameObject GetRandomSpawnLocation()
    {

        int numSpawners = _spawners.Count - 1;
        Random random = new Random();

        int randomSpawnerIndex = random.Next(0, numSpawners);

        return  _spawners[randomSpawnerIndex];
    }
    
    void SpawnEnemy(GameObject enemy)
    {
        GameObject spawnLoc = GetRandomSpawnLocation();

        GameObject temp = Instantiate(enemy, new Vector3(spawnLoc.GetComponent<Tile>().GetCartesianXPos(), spawnLoc.gameObject.transform.position.y + (transform.lossyScale.y * transform.lossyScale.y), spawnLoc.GetComponent<Tile>().GetCartesianYPos()), Quaternion.identity);
        temp.transform.parent = GameObject.FindGameObjectWithTag("EnemyContainer").transform;

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

// Shamelessly based on to a fair extent, Brackeys How to make a Tower Defense Game series from youtube
// Link : https://www.youtube.com/playlist?list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0
// Tried to do this several times on my own, and due to time, desperately needed a temporary and editable alternative.

public class WaveSpawner : MonoBehaviour
{

    public int EnemiesAlive { get; set; }

    public Wave[] waves;

    private List<GameObject> _spawners = new List<GameObject>();

    [SerializeField]
    public float timeBetweenWaves = 10f;
    [SerializeField]
    public float initialCountdownDelay = 20f;

    [SerializeField] private TextMeshProUGUI waveCountdownText;
    [SerializeField] private TextMeshProUGUI waveCountText;
    
    
    public int WaveIndex { get; private set; }

    private void Start()
    {
        foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("EnemySpawn"))
        {
            //Debug.Log("Adding spawner @ x : " + spawner.GetComponent<Tile>().GetCartesianXPos()  + ", y: " + spawner.GetComponent<Tile>().GetCartesianYPos() + " to the list");
            _spawners.Add(spawner);
        }
        WaveIndex = 0;
    }

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (WaveIndex == waves.Length)
        {
            this.enabled = false;
        }

        if (initialCountdownDelay <= 0f)
        {
            StartCoroutine(SpawnWave());
            initialCountdownDelay = timeBetweenWaves;
            return;
        }

        initialCountdownDelay -= Time.deltaTime;

        initialCountdownDelay = Mathf.Clamp(initialCountdownDelay, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", initialCountdownDelay);
        waveCountText.text = "Wave : " + WaveIndex + "/" + waves.Length;
    }


    IEnumerator SpawnWave()
    {
        PlayerStats.WavesSurvived++;

        Wave wave = waves[WaveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        WaveIndex++;
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
        temp.transform.parent = transform;
    }
}

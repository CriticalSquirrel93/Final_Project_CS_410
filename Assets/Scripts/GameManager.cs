using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public static bool isPaused;
    public static bool isVictorious;

    private int _cropValue;
    
    public WaveSpawner waveSpawner;
    [HideInInspector]
    public PlayerStats playerStats;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject victoryUI;
    [SerializeField]
    private GameObject cropContainer;

    private void Awake()
    {
        waveSpawner = GetComponent<WaveSpawner>();
        playerStats = GetComponent<PlayerStats>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _cropValue = playerStats.startingHp / cropContainer.transform.childCount;
        
        gameIsOver = false;
        isPaused = false;
        isVictorious = false;
        // jasmine did this 
        gameOverUI.SetActive(false);
        pauseUI.SetActive(false);
        victoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If game is over, stop updating stuff.
        if (gameIsOver)
        {
            return;
        }

        // If game is paused, stop time.
        if (!isPaused && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        // If HP hits zero. Lose game.
        if (playerStats.PlayerHp <= 0)
        {
            GameOver();
        }

        // If last wave & all enemies are dead. Win the game.
        if (waveSpawner.WaveIndex >= waveSpawner.waves.Length && waveSpawner.EnemiesAlive == 0)
        {
            Win();
        }

        if (cropContainer.transform.childCount * _cropValue > playerStats.PlayerHp && cropContainer.transform.childCount > 1)
        {
            Destroy(cropContainer.transform.GetChild(0).gameObject);
        }
    }

    void GameOver()
    {
        gameIsOver = true;
        //gameOverText.enabled = true;
        gameOverUI.SetActive(true); // jasmine did 
        Pause();

        // Stop the audio
        AudioSource audioSource = FindObjectOfType<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void Win()
    {
        gameIsOver = true;
        victoryUI.SetActive(true);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        if (!isPaused)
        {
            if (gameIsOver != true) {
            isPaused = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0;
            }
            //pauseUI.SetActive(true);
        }
        else
        {
            isPaused = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1;
            //pauseUI.SetActive(false);
        }
    }
}

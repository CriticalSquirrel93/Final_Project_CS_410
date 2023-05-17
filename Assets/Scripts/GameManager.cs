using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public static bool isPaused;

    [SerializeField] private Object MainMenuScene;

    [SerializeField]
    private TextMeshProUGUI gameOverText;

    public GameObject gameOverUI;
    public GameObject victoryUI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameIsOver = false;
        isPaused = false;
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (!isPaused && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        if (PlayerStats.PlayerHp <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        GameIsOver = true;
        gameOverText.enabled = true;
        gameOverUI.SetActive(true);
        Pause();
    }

    public void Win()
    {
        GameIsOver = true;
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
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(MainMenuScene.name);
    }
}

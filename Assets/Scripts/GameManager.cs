using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public static bool isPaused;

    [SerializeField] private Object MainMenuScene;

    public GameObject gameOverUI;
    public GameObject victoryUI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (PlayerStats.PlayerHp <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void Win()
    {
        GameIsOver = true;
        victoryUI.SetActive(true);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

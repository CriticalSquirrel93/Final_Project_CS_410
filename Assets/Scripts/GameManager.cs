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

    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject victoryUI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameIsOver = false;
        isPaused = false;
        //gameOverText.enabled = false;
        // jasmine did this 
        gameOverUI.SetActive(false);
        pauseUI.SetActive(false);

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
        //gameOverText.enabled = true;
        gameOverUI.SetActive(true); // jasmine did 
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
            pauseUI.SetActive(true);
            Time.timeScale = 0;
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

    public void MainMenu()
    {
        SceneManager.LoadScene(MainMenuScene.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Object level1;

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//using UnityEngine.InputSystem;
//using TMPro;

public class GameOverRat : MonoBehaviour
{
    public TextMeshProUGUI lossText;
    public GameObject gameOverObject;


    // Start is called before the first frame update
    void Start()
    {
        lossText.text = "";
    }

    // Update is called once per frame
    void Update()
    {   
    }

    void OnCollisionEnter(Collision col)
    {
       if (col.gameObject.CompareTag("Goal"))
       {
           lossText.text = "Game Over";
       }
    }
}

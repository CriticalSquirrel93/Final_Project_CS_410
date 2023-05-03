using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//using UnityEngine.InputSystem;
//using TMPro;

public class GameOverRat : MonoBehaviour
{
    public TextMeshProUGUI LossText;


    // Start is called before the first frame update
    void Start()
    {
       LossText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
    }

    void OnCollision(Collision col)
    {
       if (col.gameObject.CompareTag("Goal")) { 
           LossText.gameObject.SetActive(true);
       }
    }
}

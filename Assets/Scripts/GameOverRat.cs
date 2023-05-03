using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
//using TMPro;

public class GameOverRat : MonoBehaviour
{
    public GameObject loseTextObject;
    // Start is called before the first frame update
    void Start()
    {
       loseTextObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {   
    }

    void OnCollision(Collision col)
    {
 //       if (col.GameObject.name("Goal")) {
   //         loseTextObject.SetActive(true);
  //     }
    }
}

 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 
 // added this script bc buttons were not working anymore for some reason !
 // this is for the start scene to click the level 1 buttons. 
 
 public class SceneChanger : MonoBehaviour
 {
     public void ChangeScene(Object sceneLevel)
     {
         SceneManager.LoadScene(sceneLevel.name);
         //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
     }
     
     // Quits game
     public void Quit()
     {
         Debug.Log("Exiting");
         Application.Quit();
     }
 }
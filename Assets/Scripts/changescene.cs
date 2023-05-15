 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 
 // added this script bc buttons were not working anymore for some reason !
 // this is for the start scene to click the level 1 buttons. 
 
 public class changescene : MonoBehaviour
 {
 
     public void LoadSceneSelect(string sceneLevel)
     {
         SceneManager.LoadScene(sceneLevel);
     }
 }
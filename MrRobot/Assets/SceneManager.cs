using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void restart(){
        Application.LoadLevel (Application.loadedLevel);
    }

    public void quit(){
        Application.Quit();
    }
     public void Play(){
         Application.LoadLevel ("Testing");
    }
    public void Exit(){
         Application.LoadLevel ("UI");
    }
}

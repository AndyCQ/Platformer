using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SwitchSceneManual : MonoBehaviour
{
    public string Go;
    public void SwitchScene(){
        SceneManager.LoadScene(Go);
    }
    public void QuitGame(){
        print("quit");
        Application.Quit();
    }
}

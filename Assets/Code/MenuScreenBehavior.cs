using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreenBehavior : MonoBehaviour
{
    public string SceneToGo;
    public void SwitchScene(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneToGo);
    }

    public void QuitGame(){
        Application.Quit();
    }
}

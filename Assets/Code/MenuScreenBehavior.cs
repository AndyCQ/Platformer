using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreenBehavior : MonoBehaviour
{
    public string SceneToGo;
    public void SwitchScene(){
        SceneManager.LoadScene(SceneToGo);
    }

    public void QuitGame(){
        Application.Quit();
    }
}

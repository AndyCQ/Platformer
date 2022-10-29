using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuScreenBehavior : MonoBehaviour
{
    public GameObject pauseFirstButton, optionsFirstButton, optionsClosedButton;
    public string SceneToGo;

    private void Start() {
    EventSystem.current.SetSelectedGameObject(null);
    EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void setStart(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }
    public void setClosed(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }
    public void SwitchScene(){
        SceneManager.LoadScene(SceneToGo);
    }

    public void QuitGame(){
        print("quit");
        Application.Quit();
    }
}

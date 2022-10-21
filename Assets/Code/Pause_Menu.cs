using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject UI;


    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Paused){
                Resume();
            } else{
                Pause();
            }
        }
    }

    public void Resume(){
        UI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    void Pause(){
        UI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchCode : MonoBehaviour
{
    public string SceneToGo;
    public void SwitchScene(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneToGo);
    }
}
 
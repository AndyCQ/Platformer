using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchCode : MonoBehaviour
{
    public string SceneToGo;
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Time.timeScale = 1f;
            PublicVars.playerSpawnPoint = new Vector2(0,0);
            SceneManager.LoadScene(SceneToGo);
        }
    }
}
 
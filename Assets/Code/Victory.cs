using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public GameObject win;
    public GameObject neutral;
    public GameObject defeat;
    public GameObject monster;

    void Start(){
        int killed = PublicVars.killed;
        if( killed< 30){
            defeat.SetActive(true);
        } else if(killed < 60){
            neutral.SetActive(true);
        } else if(killed < 100){
            win.SetActive(true);
        } else{
            monster.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldLerp : MonoBehaviour
{
    public GameObject[] platforms;
    public int currentIndex = 0;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){Moveup();}
        if(Input.GetKeyDown(KeyCode.S)){MoveDown();}
           
    }
    void Moveup(){
        if(currentIndex < 4 && PublicVars.l_status[currentIndex]){
            GameObject destination = platforms[currentIndex+1];
            currentIndex++;
            gameObject.transform.position = destination.transform.position;
        }
    }

    void MoveDown(){
        if(currentIndex > 0){
            GameObject destination = platforms[currentIndex-1];
            currentIndex--;
            gameObject.transform.position = destination.transform.position;
        }
    }

}

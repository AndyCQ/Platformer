using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldLerp : MonoBehaviour
{
    public GameObject[] platforms;
    int currentIndex = 0;
    float moveSpeed = .1f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){Moveup();}
        if(Input.GetKeyDown(KeyCode.S)){MoveDown();}
           
    }
    IEnumerator Moveup(){
        float t = 0;
        while(t < .8f){
            if(currentIndex < 4){
                transform.position = Vector3.Lerp(transform.position, platforms[currentIndex+1].transform.position,t*moveSpeed);
                t += Time.deltaTime;
                yield return null;
            } else{
                t = 1f;
                yield return null;
            }
        }
    }

    IEnumerator MoveDown(){
        float t = 0;
        while(t < .8f){
            if(currentIndex > 0){
                transform.position = Vector3.Lerp(transform.position, platforms[currentIndex-1].transform.position,t*moveSpeed);
                t += Time.deltaTime;
                yield return null;
            } else{
                t = 1f;
                yield return null;
            }
        }
    }

}

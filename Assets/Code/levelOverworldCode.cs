using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class levelOverworldCode : MonoBehaviour
{
    public int index;
    public Sprite Complete;
    public Sprite in_progress;
    void FixedUpdate()
    {
        if(PublicVars.l_status[index]){
            gameObject.GetComponent<Image>().sprite = Complete;
        } else{
            gameObject.GetComponent<Image>().sprite = in_progress;
        }
    }
}

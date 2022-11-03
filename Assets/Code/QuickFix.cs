using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PublicVars.toggle){
            PublicVars.toggle = false;
        } else{
            gameObject.SetActive(false);
        }
    }
}

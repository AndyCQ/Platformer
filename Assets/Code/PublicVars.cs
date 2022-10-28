using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class PublicVars 
{
    
    public static Vector2 playerSpawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    public static int activeGun;
}

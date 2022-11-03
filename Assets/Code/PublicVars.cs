using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class PublicVars 
{
    
    public static Vector2 playerSpawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    public static int activeGun;

    public static bool toggle = true;
    public static int[] unlockedGuns = {1,1,1};
    public static int bulletDMG = 2;
    public static int bullet_smgDMG = 1;
    public static int bullet_BIGDMG = 8;
    public static int bullet_homingDMG = 3;

    public static int killed = 0;
    public static bool done = false;
    public static bool[] l_status = {true,true,true,false};
}

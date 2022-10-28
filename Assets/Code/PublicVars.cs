using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class PublicVars 
{
    
    public static Vector2 playerSpawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    public static int activeGun;
    public static int[] unlockedGuns = {1,1,1};
    public static int bulletDMG = 2;
    public static int bullet_smgDMG = 1;
    public static int bullet_BIGDMG = 8;
    public static int bullet_homingDMG = 3;
}

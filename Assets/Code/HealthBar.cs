using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int healthNum;
    public GameObject IMG;
    public Sprite full;
    public Sprite half;
    public Sprite empty;
    
    public GameObject player;
    public GameObject[] hearts;

    void Start()
    {
        healthNum = player.GetComponent<PlayerCode>().maxHealth;
    }

    void DecreaseHealth(){
        print("sus");
    }
}

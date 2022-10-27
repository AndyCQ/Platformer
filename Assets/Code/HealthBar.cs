using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    int healthNum;
    int heartNum;
    public GameObject IMG;
    public Sprite full;
    public Sprite half;
    public Sprite empty;
    
    public GameObject player;
    private GameObject[] hearts;

    void Start()
    {
        heartNum = player.maxHealth/2;
        healthNum = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

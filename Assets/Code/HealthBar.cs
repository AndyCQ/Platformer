using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void UpdateHearts(){
        switch(healthNum){
            case 0:
                hearts[0].GetComponent<Image>().sprite = empty;
                hearts[1].GetComponent<Image>().sprite = empty;
                hearts[2].GetComponent<Image>().sprite = empty;
                break;
            case 1:
                hearts[0].GetComponent<Image>().sprite = half;
                hearts[1].GetComponent<Image>().sprite = empty;
                hearts[2].GetComponent<Image>().sprite = empty;
                break;
            case 2:
                hearts[0].GetComponent<Image>().sprite = full;
                hearts[1].GetComponent<Image>().sprite = empty;
                hearts[2].GetComponent<Image>().sprite = empty;
                break;
            case 3:
                hearts[0].GetComponent<Image>().sprite = full;
                hearts[1].GetComponent<Image>().sprite = half;
                hearts[2].GetComponent<Image>().sprite = empty;
                break;
            case 4:
                hearts[0].GetComponent<Image>().sprite = full;
                hearts[1].GetComponent<Image>().sprite = full;
                hearts[2].GetComponent<Image>().sprite = empty;
                break;
            case 5:
                hearts[0].GetComponent<Image>().sprite = full;
                hearts[1].GetComponent<Image>().sprite = full;
                hearts[2].GetComponent<Image>().sprite = half;
                break;
            case 6:
                hearts[0].GetComponent<Image>().sprite = full;
                hearts[1].GetComponent<Image>().sprite = full;
                hearts[2].GetComponent<Image>().sprite = full;
                break;
            default:
                print("This shouldn't happen");
                break;
        }
    }

    public void DecreaseHealth(){
        healthNum--;
        UpdateHearts();
    }
    public void IncreaseHealth(){
        healthNum++;
        UpdateHearts();
    }
}

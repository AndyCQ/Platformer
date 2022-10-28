using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunStorage : MonoBehaviour
{
    public int primaryShots = 0;
    public int storeSecondary = 0;
    public int storedGun = 0;

    public int focusSecond = 1;

    public int secRounds = 0;

    public GameObject[] primaryStored;
    public GameObject[] secondStored;
    public GameObject[] uiGuns;
    public GameObject[] bullets;

    private Color white = new Color32(255,255,225,255);
    private Color black = new Color32(50, 50, 50,255);
    private Color red = new Color32(255,0,0,255);

    void Awake(){
        updateUI();
        if(PublicVars.unlockedGuns[0] != 0){
            storedGun = 1;
        }
    }

    public void primaryFire(){
        primaryShots++;
        if(primaryShots > 4){
            if(storeSecondary < 3){
                primaryShots = 0;
                storeSecondary++;
            } else{
                primaryShots = 4;
            }
        }
        updateUI();
    }
    public bool secondFire(){
        if(secRounds == 0 && storeSecondary == 0){
            FindObjectOfType<MusicManager>().PlaySoundEffects("empty_mag");
            return false;
        }
        if(secRounds > 0){
            secRounds--;
        } else{
            if(PublicVars.activeGun == 1){
                secRounds = 15;
            } else{
                if(PublicVars.activeGun == 2){
                    secRounds = 0;
                } else{
                    secRounds = 5;
                }
            }
            storeSecondary--;
        }
        updateUI();
        return true;
    }

    public void Shooting(int bulletForce,Transform firePoint, float dir){
        GameObject newBullet;
        GameObject newBullet1;
        GameObject newBullet2;
        float bulletSpeed = 1f*dir;
        switch(PublicVars.activeGun){
            case 0:
                primaryFire();
                newBullet = Instantiate(bullets[0], firePoint.position, Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed,0) * bulletForce);
                FindObjectOfType<MusicManager>().PlaySoundEffects("blast");
                break;
            case 1:
                if(secondFire()){
                    newBullet = Instantiate(bullets[1], firePoint.position, Quaternion.identity);
                    newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed*2f,0) * bulletForce);
                    FindObjectOfType<MusicManager>().PlaySoundEffects("light_blast");
                    FindObjectOfType<MusicManager>().PlaySoundEffects("light_blast");
                    FindObjectOfType<MusicManager>().PlaySoundEffects("light_blast");
                }
                break;
            case 2:
                if(secondFire()){
                    newBullet = Instantiate(bullets[2], firePoint.position, Quaternion.identity);
                    newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed/2f,0) * bulletForce);
                    FindObjectOfType<MusicManager>().PlaySoundEffects("heavy_blast");
                }
                break;
            case 3:
                if(secondFire()){
                    newBullet = Instantiate(bullets[3], firePoint.position, Quaternion.identity);
                    newBullet1 = Instantiate(bullets[3], firePoint.position, Quaternion.identity);
                    newBullet2 = Instantiate(bullets[3], firePoint.position, Quaternion.identity);
                    newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed,0) * bulletForce);
                    newBullet1.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed,1) * bulletForce);
                    newBullet2.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed,-1) * bulletForce);
                    FindObjectOfType<MusicManager>().PlaySoundEffects("multiblast");
                }
                break;
            default:
                print("This shouldn't happen");
                break;
        }
    }

    public void updateUI(){
        switch(primaryShots){
            case 0:
                primaryStored[0].GetComponent<Image>().color = black;
                primaryStored[1].GetComponent<Image>().color = black;
                primaryStored[2].GetComponent<Image>().color = black;
                primaryStored[3].GetComponent<Image>().color = black;
                break;
            case 1:
                primaryStored[0].GetComponent<Image>().color = white;
                primaryStored[1].GetComponent<Image>().color = black;
                primaryStored[2].GetComponent<Image>().color = black;
                primaryStored[3].GetComponent<Image>().color = black;
                break;
            case 2:
                primaryStored[0].GetComponent<Image>().color = white;
                primaryStored[1].GetComponent<Image>().color = white;
                primaryStored[2].GetComponent<Image>().color = black;
                primaryStored[3].GetComponent<Image>().color = black;
                break;
            case 3:
                primaryStored[0].GetComponent<Image>().color = white;
                primaryStored[1].GetComponent<Image>().color = white;
                primaryStored[2].GetComponent<Image>().color = white;
                primaryStored[3].GetComponent<Image>().color = black;
                break;
            case 4:
                primaryStored[0].GetComponent<Image>().color = white;
                primaryStored[1].GetComponent<Image>().color = white;
                primaryStored[2].GetComponent<Image>().color = white;
                primaryStored[3].GetComponent<Image>().color = white;
                break;
            default:
                print("This shouldn't happen");
                break;
        }

        switch(storeSecondary){
            case 0:
                if(secRounds>0){
                    secondStored[0].GetComponent<Image>().color = red;
                } else{
                    secondStored[0].GetComponent<Image>().color = black;
                }
                secondStored[1].GetComponent<Image>().color = black;
                secondStored[2].GetComponent<Image>().color = black;
                break;
            case 1:
                secondStored[0].GetComponent<Image>().color = white;
                if(secRounds>0){
                    secondStored[1].GetComponent<Image>().color = red;
                } else{
                    secondStored[1].GetComponent<Image>().color = black;
                }
                secondStored[2].GetComponent<Image>().color = black;
                break;
            case 2:
                secondStored[0].GetComponent<Image>().color = white;
                secondStored[1].GetComponent<Image>().color = white;
                if(secRounds>0){
                    secondStored[2].GetComponent<Image>().color = red;
                } else{
                    secondStored[2].GetComponent<Image>().color = black;
                }
                    
                break;
            case 3:
                secondStored[0].GetComponent<Image>().color = white;
                secondStored[1].GetComponent<Image>().color = white;
                secondStored[2].GetComponent<Image>().color = white;
                break;
            default:
                print("This shouldn't happen");
                break;
        }
        switch(focusSecond){
            case 1:
                uiGuns[0].SetActive(true);
                uiGuns[1].SetActive(false);
                uiGuns[2].SetActive(false);
                if(PublicVars.unlockedGuns[0] == 0){
                    uiGuns[0].GetComponent<Image>().color = black;
                } else{
                    uiGuns[0].GetComponent<Image>().color = white;
                }
                break;
            case 2:
                uiGuns[0].SetActive(false);
                uiGuns[1].SetActive(true);
                uiGuns[2].SetActive(false);
                if(PublicVars.unlockedGuns[1] == 0){
                    uiGuns[1].GetComponent<Image>().color = black;
                } else{
                    uiGuns[1].GetComponent<Image>().color = white;
                }
                break;
            case 3:
                uiGuns[0].SetActive(false);
                uiGuns[1].SetActive(false);
                uiGuns[2].SetActive(true);
                if(PublicVars.unlockedGuns[2] == 0){
                    uiGuns[2].GetComponent<Image>().color = black;
                } else{
                    uiGuns[2].GetComponent<Image>().color = white;
                }
                break;
            default:
                print("This shouldn't happen");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Tab)){
            Time.timeScale = 0f;
            Pause_Menu.Paused = true;
            if(Input.GetKeyDown(KeyCode.W)){
                if(focusSecond<2){
                    focusSecond = 4;
                }
                focusSecond--;
                updateUI();
                if(PublicVars.unlockedGuns[focusSecond-1] == 1 && PublicVars.activeGun != 0){
                    PublicVars.activeGun = focusSecond;
                    storedGun = focusSecond;
                }
            }
            if(Input.GetKeyDown(KeyCode.S)){
                if(focusSecond>2){
                    focusSecond = 0;
                }
                focusSecond++;
                updateUI();
                if(PublicVars.unlockedGuns[focusSecond-1] == 1 && PublicVars.activeGun != 0){
                    PublicVars.activeGun = focusSecond;
                    storedGun = focusSecond;
                }
            }
        }
        if(Input.GetKeyUp(KeyCode.Tab)){
            Time.timeScale = 1f;
            Pause_Menu.Paused = false;
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            if(PublicVars.activeGun == 0){
                if(storedGun == 0){
                    print("Not Yet Unlocked");
                } else{
                    if(PublicVars.unlockedGuns[focusSecond-1] == 1){
                        PublicVars.activeGun = focusSecond;
                        storedGun = focusSecond;
                    } else{
                        PublicVars.activeGun = 1;
                        storedGun = 1;
                        focusSecond = 1;
                    }
                }
            } else{
                if(PublicVars.unlockedGuns[focusSecond-1] == 1){
                    storedGun = PublicVars.activeGun;
                    focusSecond = PublicVars.activeGun;
                    PublicVars.activeGun = 0;
                } else{
                        PublicVars.activeGun = 0;
                        storedGun = 1;
                        focusSecond = 1;
                }
            }
            updateUI();
        }

    }
}


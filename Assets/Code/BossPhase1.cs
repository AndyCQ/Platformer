using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase1 : MonoBehaviour
{
    float moveSpeed = .01f;
    float aimSpeed = .5f;
    int bulletForce = 500;
    float speed = 3;
    public float distance = 10;

    public int currHealth;
    public int maxHealth = 50;

    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;

    Transform player;
    Vector2 startingPos;
    Rigidbody2D _rigidbody;

    public Transform Canon1;
    public Transform Canon2;
    public Transform mainCanon;

    public GameObject End;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        NextAttack();
        startingPos = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        currHealth = maxHealth;
    }

    void NextAttack(){
        StopAllCoroutines();
        int state = Random.Range(0,5);
        switch(state)
        {
            case 0:
                StartCoroutine(AimAttack());
                break;
            case 1:
                StartCoroutine(BlindAttack());
                break;
            case 3:
                StartCoroutine(MoveToPlayer());
                break;
            default:
                StartCoroutine(Idle());
                break;
        }

    }

    IEnumerator Idle(){
        yield return new WaitForSeconds(1);
        NextAttack();
    }

    IEnumerator AimAttack(){
        StartCoroutine(Fire(4, .5f, .5f));
        float t = 0;
        while(t < 1){
            mainCanon.up = Vector3.Lerp(-mainCanon.up, player.position - mainCanon.position, t);
            t += aimSpeed * Time.deltaTime;
            yield return null;
        }
        yield return StartCoroutine(ResetRotation());
        NextAttack();
    }

    IEnumerator MoveToPlayer(){
        float t = 0;
        while(t< .8f){
            transform.position = Vector2.Lerp(transform.position, player.position, t*moveSpeed);
            t += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(returnToOriginalPos());
        yield return new WaitForSeconds(1);
        
        NextAttack();
    }

    IEnumerator Fire(int shotNUm, float reload, float delay){
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < shotNUm; i++){
            GameObject newBullet = Instantiate(bulletPrefab1, mainCanon.position, transform.rotation * Quaternion.Euler(0,0,90));
            newBullet.GetComponent<Rigidbody2D>().AddForce(mainCanon.up * bulletForce);
            yield return new WaitForSeconds(reload);
        }
    }

    IEnumerator ResetRotation(){
        float t = 0;
        while(t < 1){
            mainCanon.up = Vector3.Lerp(mainCanon.up, Vector2.up, t);
            t += Time.deltaTime;
            yield return null;
        }
        mainCanon.rotation = Quaternion.identity;
    }

    IEnumerator returnToOriginalPos(){
        float t = 0;
        while(t < 1){
            transform.position = Vector2.Lerp(transform.position, startingPos, t*moveSpeed);
            t += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator BlindAttack(){
        float t = 0;
        while (t < 40)
        {   
            yield return new WaitForSeconds(.1f);

            if(transform.position.x >= startingPos.x +distance || (transform.position.x < (startingPos.x - distance))){
                //yield return new WaitForSeconds(.5f);
                transform.localScale *= new Vector2(-1,1);
                _rigidbody.velocity = new Vector2(speed* transform.localScale.x, _rigidbody.velocity.y);
            }
            else{
                _rigidbody.velocity = new Vector2(speed* transform.localScale.x, _rigidbody.velocity.y);
            }
            // if(player.position.x > transform.position.x && transform.localScale.x < 0 || 
            // player.position.x < transform.position.x && transform.localScale.x > 0)
            //     { 
            //         transform.localScale *= new Vector2(-1,1);
            //     }
            
            //_rigidbody.velocity = new Vector2(speed* transform.localScale.x, _rigidbody.velocity.y);
            GameObject newBullet1 = Instantiate(bulletPrefab2, Canon1.position, transform.rotation * Quaternion.Euler(0,0,90));
            newBullet1.GetComponent<Rigidbody2D>().AddForce(-transform.up * bulletForce);  
            GameObject newBullet2 = Instantiate(bulletPrefab2, Canon2.position, transform.rotation * Quaternion.Euler(0,0,90));
            newBullet2.GetComponent<Rigidbody2D>().AddForce(-transform.up * bulletForce);  
            t += 1;
        }
        _rigidbody.velocity = new Vector2(0,0);
        StartCoroutine(returnToOriginalPos());
        yield return new WaitForSeconds(1);
        NextAttack();
        }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")){
            Destroy(other.gameObject);
            currHealth -= PublicVars.bulletDMG;
        }
        if (other.CompareTag("Bullet_smg")){
            Destroy(other.gameObject);
            currHealth -= PublicVars.bullet_smgDMG;
        } 
        if (other.CompareTag("Bullet_Big")){
            Destroy(other.gameObject);
            currHealth -= PublicVars.bullet_BIGDMG;
        } 
        if (other.CompareTag("Bullet_homing")){
            Destroy(other.gameObject);
            currHealth -= PublicVars.bullet_homingDMG;
                                
        }
        if(currHealth <= 0){
                Die();
            }
    }

    void Die() {
        End.SetActive(true);
        Destroy(gameObject,.15f);
    }

}

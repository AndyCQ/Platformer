using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOCode : MonoBehaviour
{
    public float speed = 3;
    public float lookDist = 5;

    public int currHealth;
    public int maxHealth = 3;

    Rigidbody2D _rigidbody;
    Transform player;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public int bulletForce = 500;

    void Start()
    {
        currHealth = maxHealth;
        _rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(MoveLoop());
    }
    
    IEnumerator MoveLoop(){
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if (Vector2.Distance(transform.position, player.position) < lookDist){
                if(player.position.x > transform.position.x && transform.localScale.x < 0 || 
                player.position.x < transform.position.x && transform.localScale.x > 0)
                {
                    yield return new WaitForSeconds(.5f);
                    transform.localScale *= new Vector2(-1,1);
                }
                
                _rigidbody.velocity = new Vector2(speed* transform.localScale.x, _rigidbody.velocity.y);

                yield return new WaitForSeconds(.5f);
                GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation * Quaternion.Euler(0,0,90));
                newBullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * bulletForce);   
                // Tracking Version
                //newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2((player.position.x - transform.position.x),(player.position.y - transform.position.y)) * bulletForce);   
            }

            //Platform version
            else {
                _rigidbody.velocity = Vector2.zero;
            }
        }
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
        Destroy(gameObject,.15f);
    }

}

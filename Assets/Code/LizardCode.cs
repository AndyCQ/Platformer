using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardCode : MonoBehaviour
{
    public float speed = 4;
    public float lookDist = 4;

    public int currHealth;
    public int maxHealth = 5;

    public LayerMask GroundWallLayer;
    Rigidbody2D _rigidbody;
    Transform player;
    public Transform castPoint;

    private float startPosition;

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
                    transform.localScale *= new Vector2(-1,1);
                }
                yield return new WaitForSeconds(.5f);
                GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x,0) * bulletForce);   
            }

            //Platform version
            else if((Physics2D.Raycast(castPoint.position, transform.forward, 1, GroundWallLayer)) ||
            !Physics2D.Raycast(castPoint.position,-transform.up,1,GroundWallLayer))
            {
                transform.localScale *= new Vector2(-1,1);
            }
            _rigidbody.velocity = new Vector2(speed* transform.localScale.x, _rigidbody.velocity.y);

            //Distance version
            // else if(transform.position.x >= startPosition+distance || (transform.position.x < (startPosition))){
            //     transform.localScale *= new Vector2(-1,1);
            //     _rigidbody.velocity = new Vector2(speed* transform.localScale.x, _rigidbody.velocity.y);
            // }
            // else{
            //     _rigidbody.velocity = new Vector2(speed* transform.localScale.x, _rigidbody.velocity.y);
            // }
        }
    }
  

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")){
            Destroy(other.gameObject);
            currHealth -= 1;
            if(currHealth <= 0){
                Die();
            }
        }
    }



    void Die() {
        Destroy(gameObject,.15f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCode : MonoBehaviour
{
    public int speed = 5;
    public int jumpForce = 500;
    public int bulletForce = 500;

    public LayerMask groundLayer;
    public Transform feetTrans;
    public bool grounded = false;

    public GameObject bulletPrefab;
    public Transform firePoint;

    Rigidbody2D _rigidbody;
    Animator _animator;

    Vector2 playerSpawnPoint;
    bool isDead = false;
    SpriteRenderer _renderer;

    public float deathLevel = -5;

    public int currHealth;
    public int maxHealth = 5;

    float xSpeed = 0;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        playerSpawnPoint = transform.position;
        _renderer = GetComponent<SpriteRenderer>();

        currHealth = maxHealth;
    }

    void FixedUpdate()
    {
        if(isDead) return;
        xSpeed = Input.GetAxisRaw("Horizontal") * speed;
        if((xSpeed < 0 && transform.localScale.x > 0) || (xSpeed > 0 && transform.localScale.x < 0))
        {
            transform.localScale *= new Vector2(-1,1);
        }

        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
        _animator.SetFloat("Speed", Mathf.Abs(xSpeed));
        if(transform.position.y < deathLevel){
            transform.position = playerSpawnPoint;
            StartCoroutine(PlayerRespawn());
        }

    }

    private void Update() {

        if(isDead) return;

        grounded = Physics2D.OverlapCircle(feetTrans.position, .3f, groundLayer);
        _animator.SetBool("Grounded", grounded);
        if(Input.GetButtonDown("Jump") && grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
        if(Input.GetButtonDown("Fire1")){
            _animator.SetTrigger("Shoot");
            GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x,0) * bulletForce);
        }

        if(currHealth > maxHealth){
            currHealth = maxHealth;
        }
        if(currHealth <= 0){
            Die();
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            transform.position = playerSpawnPoint;
            StartCoroutine(PlayerRespawn());
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Checkpoint")){
            playerSpawnPoint = other.transform.position;
        }
    }



    IEnumerator PlayerRespawn(){
        isDead = true;
        yield return null;
        _renderer.enabled = false;
        yield return new WaitForSeconds(1);
        isDead = false;
        _renderer.enabled = true;

    }

    void Die() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Damage(int dmg){
        currHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("GetsHit");
        
    }

    public IEnumerator Knockback (float knockDur, float knockbackPwr, Vector3 knockbackDir){
        float timer = 0;
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);

        while (knockDur > timer) {
            timer += Time.deltaTime;
            _rigidbody.AddForce(new Vector3(knockbackDir.x + -1000, knockbackDir.y + knockbackPwr, transform.position.z));
        }

        yield return 0;
    }

} 

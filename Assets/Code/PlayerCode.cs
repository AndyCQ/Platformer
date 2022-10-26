using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCode : MonoBehaviour
{
    public int speed = 5;
    public int jumpForce = 500;
    

    public LayerMask groundLayer;
    public Transform feetTrans;
    public bool grounded = false;

    public GameObject bulletPrefab;
    public int bulletForce = 500;
    public Transform firePoint;

    Rigidbody2D _rigidbody;
    Animator _animator;

    bool isDead = false;
    SpriteRenderer _renderer;

    public float deathLevel = -5;

    public int currHealth;
    public int maxHealth = 5;

    //dashing code
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 2.5f;

    [SerializeField] private TrailRenderer tr;

    float xSpeed = 0;
    
    private void Awake() {
        transform.position = PublicVars.playerSpawnPoint;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        PublicVars.playerSpawnPoint = transform.position;
        _renderer = GetComponent<SpriteRenderer>();
        currHealth = maxHealth;
    }

    void FixedUpdate()
    {

        if (isDashing)
        {
            return;
        }
        if(isDead) return;
        xSpeed = Input.GetAxisRaw("Horizontal") * speed;
        if((xSpeed < 0 && transform.localScale.x > 0) || (xSpeed > 0 && transform.localScale.x < 0))
        {
            transform.localScale *= new Vector2(-1,1);
        }
        //print(Time.fixedDeltaTime);
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
        _animator.SetFloat("Speed", Mathf.Abs(xSpeed));

        if(transform.position.y < deathLevel){
            transform.position = PublicVars.playerSpawnPoint;
            Die();
        }

    }

    private void Update() {

        if (isDashing){
            return;
        }

        if(isDead) return;

        grounded = Physics2D.OverlapCircle(feetTrans.position, .3f, groundLayer);
        _animator.SetBool("Grounded", grounded);
        if(Input.GetButtonDown("Jump") && grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
        if(Input.GetButtonDown("Fire1")){
            if(!Pause_Menu.Paused){
                _animator.SetTrigger("Shoot");
                GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x,0) * bulletForce);
                FindObjectOfType<MusicManager>().PlaySoundEffects("blast");
            }
        }

        if(currHealth > maxHealth){
            currHealth = maxHealth;
        }
        if(currHealth <= 0){
            Die();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.CompareTag("Enemy"))
    //     {
    //         transform.position = PublicVars.playerSpawnPoint;
    //         Damage(1);
    //     }

    // }

    private void OnTriggerEnter2D(Collider2D other) {
        switch(other.tag){
            case "Checkpoint":
                PublicVars.playerSpawnPoint = other.transform.position;
                break;
            
            case "EnemyBullet":
                Destroy(other.gameObject);
                Damage(1);
                break;

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
        gameObject.GetComponent<Animation>().Play("GetHit");
        
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

    private IEnumerator Dash(){
        canDash = false;
        isDashing = true;
        float originalGravity = _rigidbody.gravityScale;
        _rigidbody.gravityScale = 0f;
        _rigidbody.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        _rigidbody.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
} 

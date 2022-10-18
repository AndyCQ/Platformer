using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //Animator _animator;

    float xSpeed = 0;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        //_animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        xSpeed = Input.GetAxisRaw("Horizontal") * speed;
        if((xSpeed < 0 && transform.localScale.x > 0) || (xSpeed > 0 && transform.localScale.x < 0))
        {
            transform.localScale *= new Vector2(-1,1);
        }

        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
        //_animator.SetFloat("Speed", Mathf.Abs(xSpeed));

    }

    private void Update() {

        grounded = Physics2D.OverlapCircle(feetTrans.position, .3f, groundLayer);
        //_animator.SetBool("Grounded", grounded);
        if(Input.GetButtonDown("Jump") && grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
        if(Input.GetButtonDown("Fire1")){
            GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x,0) * bulletForce);
        }
    }
} 

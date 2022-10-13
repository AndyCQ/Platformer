using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    public int speed = 5;
    public int jumpForce = 500;
    public LayerMask groundLayer;
    public Transform feetTrans;
    public bool grounded = false;

    Rigidbody2D _rigidbody;
    float xSpeed = 0;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        xSpeed = Input.GetAxisRaw("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
    }

    private void Update() {
        grounded = Physics2D.OverlapCircle(feetTrans.position, .3f, groundLayer);
        if(Input.GetButtonDown("Jump") && grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
} 

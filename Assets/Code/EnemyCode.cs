using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCode : MonoBehaviour
{
    public float xSpeed = .3f;
    public float distance = 4;
    private float startPosition;
    private float originalXPos;

    void Start()
    {
        startPosition = transform.position.x;
    }

    void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.x = Mathf.SmoothStep(startPosition, startPosition + distance, Mathf.PingPong(Time.time * xSpeed, 1));
        transform.position = newPosition;
    }
    private void FixedUpdate() {
        if((startPosition < transform.position.x) && (transform.position.x < startPosition +.0001)|| 
        ((startPosition+distance > transform.position.x) && (transform.position.x > (startPosition + distance) -.0001)))
        {
            transform.localScale *= new Vector2(-1,1); 
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")){
            Destroy(other.gameObject);
            Destroy(gameObject,.15f);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackCode : MonoBehaviour
{

    public int speed, jumpforce;

    Rigidbody2D rb;

    bool left;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Space)){{
            rb.AddForce (Vector2.up*jumpforce);
        }}
    }
}

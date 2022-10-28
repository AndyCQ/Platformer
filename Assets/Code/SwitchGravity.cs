using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerCode player;

    private bool top;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
       player = GetComponent<PlayerCode>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            rb.gravityScale *= -1;
            player.jumpForce *= -1;
            Rotation();
        }
    }

    void Rotation(){
        if(top == false){
            transform.eulerAngles = new Vector3(0,0,180f);
            transform.eulerAngles = new Vector3(180f,0,0);
        }
        else{
            transform.eulerAngles= Vector3.zero;
        }
        top = !top;
    }
}

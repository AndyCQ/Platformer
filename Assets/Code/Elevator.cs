using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{   
    public Transform player;
    public Transform elevatorswitch;
    public Transform downpos;
    public Transform upperpos;

    public float speed;
    bool iselevatordown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartElevator();
    }

    void StartElevator()
    {
        if(Vector2.Distance(player.position, elevatorswitch.posiiton)<0.5f && Input.GetKeyDown("e"))
        {
            if(transform.posiiton.y <= downpos.position.y)
            {
                iselevatordown = true;
            }
            else if (transform.position.y >= upperpos.position.y)
            {
                iselevatordown = false;
            }
        }

        if(iselevatordown)
        {
            transform.position = Vector2
        }
    }
}

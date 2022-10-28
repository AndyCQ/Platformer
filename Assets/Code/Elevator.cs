using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{   
    public Transform player;
    public Transform elevatorswitch;
    public Transform downpos;
    public Transform upperpos;
    public SpriteRenderer elevator;

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
        DisplayColor();
    }

    void StartElevator()
    {
        if(Vector2.Distance(player.position, elevatorswitch.position)<0.5f && (Input.GetKeyDown("e") || Input.GetKeyDown("joystick button 2")))
        {
            if(transform.position.y <= downpos.position.y)
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
            transform.position = Vector2.MoveTowards(transform.position, upperpos.position,speed*Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,downpos.position,speed *Time.deltaTime);
        }
    }

    void DisplayColor(){
        if(transform.position.y <= downpos.position.y || transform.position.y >= upperpos.position.y)
        {
            elevator.color = Color.green;
        }
        else{
            elevator.color = Color.red;
        }
        //if(iselevatordown)
        //{
            //transform.position = Vector2
        //}
    }
}

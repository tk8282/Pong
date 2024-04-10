using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle
{
    //variable to track paddle's direction
    private Vector2 direction;

    //called every frame, will check for logic that is constantly run
    private void Update()
    {
        //checks if up or down arrows are pressed and applies the corresponding direction
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) 
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
        }
        //to ensure no other key affects paddle movement
        else 
        {
            direction = Vector2.zero;
        }
    }

    //only called at fixed time intervals, important for physics
    private void FixedUpdate()
    {
        if (direction.sqrMagnitude != 0)
        {
            rigidbody.AddForce(direction * this.speed);
        }
    }
}

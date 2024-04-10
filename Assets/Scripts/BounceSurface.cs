using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSurface : MonoBehaviour
{

    public float bounceSpeed;

    //will be called automatically by rigidbody component
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        //check if the object that collided was the ball
        if(ball != null)
        {
            //get contact will get the first contact point
            Vector2 bounce = collision.GetContact(0).normal;

            //adding force to the ball in the correct vector direction
            ball.AddForce(-bounce * this.bounceSpeed);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{   
    //used to apply speed of the paddle
    public float speed = 12.0f;

    //variable to use the rigidbody component applied to paddles
    protected Rigidbody2D rigidbody;

    //only called once, use for initialization
    //will return the rigidbody component and apply to variable
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPaddle()
    {
        rigidbody.position = new Vector2(rigidbody.position.x, 0.0f);
        rigidbody.velocity = Vector3.zero;
    }
}

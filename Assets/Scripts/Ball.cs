using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //ball's rigidbody
    private Rigidbody2D rigidbody;

    //only called once, use for initialization
    //will return the rigidbody component and apply to variable
    private void Awake()
    {
        Debug.Log("Awake called");
        rigidbody = GetComponent<Rigidbody2D>();
    }

    //will call the 1st frame of the game
    private void Start()
    {
        Debug.Log("Start called");
        ResetBall();
        AddStartingForce();
        Debug.Log("Start called");
    }

    //
    public void ResetBall()
    {
        rigidbody.position = Vector3.zero;
        rigidbody.velocity = Vector3.zero;
    }

    //applying a random direction for the ball to start
    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        rigidbody.AddForce(direction * 200);
    }

    //method for other files to add force to the ball
    public void AddForce(Vector2 force)
    {
        rigidbody.AddForce(force);
    }
}

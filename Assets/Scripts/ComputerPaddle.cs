using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
    // Reference to the ball Rigidbody
    public Rigidbody2D ball;

    // FixedUpdate is called once per physics step
    private void FixedUpdate()
    {
        // Retrieve the selected difficulty level from PlayerPrefs
        string difficulty = PlayerPrefs.GetString("Difficulty", "Easy");

        switch (difficulty)
        {
            case "Easy":
                EasyAI();
                break;
            case "Medium":
                MediumAI();
                break;
            case "Hard":
                HardAI();
                break;
            default:
                Debug.LogError("Unknown difficulty: " + difficulty);
                break;
        }
    }

    // Easy level AI
    private void EasyAI()
    {
        Debug.Log("Easy AI");
        if(this.ball.velocity.x > 0.0f && this.ball.position.x > 4.0f)
        {
            if(this.ball.position.y > this.transform.position.y)
            {
                rigidbody.AddForce(Vector2.up * 7);
            }
            else if(this.ball.position.y < this.transform.position.y)
            {
                rigidbody.AddForce(Vector2.down * 7);
            }
        }       
        else 
        {
                rigidbody.AddForce(Vector2.zero);
        }
    }

    // Medium level AI
    private void MediumAI()
    {
        Debug.Log("Medium AI");
        //medium level tracks the ball when the ball is going in its direction
        //it also keeps the paddle in the middle when the ball is moving away to keep the distance from the top and bottom equal
        if(this.ball.velocity.x > 0.0f)
        {
            if(this.ball.position.y > this.transform.position.y)
            {
                rigidbody.AddForce(Vector2.up * 9);
            }
            else if(this.ball.position.y < this.transform.position.y)
            {
                rigidbody.AddForce(Vector2.down * 9);
            }
        }
        else 
        {
            if(this.transform.position.y > 0.0f)
            {
                rigidbody.AddForce(Vector2.down * this.speed);
            }
            else if(this.transform.position.y < 0.0f)
            {
                rigidbody.AddForce(Vector2.up * this.speed);
            }
        }
    }

    // Hard level AI (example behavior)
    private void HardAI()
    {
        Debug.Log("Hard AI");
            if(this.ball.velocity.x > 0.0f && this.ball.position.x > 0.0f)
        {
            if(this.ball.position.y > this.transform.position.y)
            {
                rigidbody.AddForce(Vector2.up * this.speed);
            }
            else if(this.ball.position.y < this.transform.position.y)
            {
                rigidbody.AddForce(Vector2.down * this.speed);
            }
        }
        else 
        {
            if(this.transform.position.y > 0.0f)
            {
                rigidbody.AddForce(Vector2.down * this.speed);
            }
            else if(this.transform.position.y < 0.0f)
            {
                rigidbody.AddForce(Vector2.up * this.speed);
            }
        }
    }
}

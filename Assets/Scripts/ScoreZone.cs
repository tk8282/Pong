using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScoreZone : MonoBehaviour
{
    //unity's event trigger
    public EventTrigger.TriggerEvent scoreTrigger;

    //will be called automatically by rigidbody component
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        //check if the object that collided was the ball
        if(ball != null)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.scoreTrigger.Invoke(eventData);
        }
    }
}

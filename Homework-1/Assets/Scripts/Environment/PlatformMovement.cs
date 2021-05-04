using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private float distance = 2;

    private Vector2 startingPosition;
    private bool isGoingUp = true;

    private Rigidbody2D body;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        startingPosition = body.position;
    }

    void Update()
    {
        float currentOffset = (startingPosition - body.position).y;
        if(currentOffset <= 0) // If we are moving up and we have surpassed the top pos.
        {
            body.position = startingPosition;
            isGoingUp = false;
        }
        if(currentOffset >= distance) // If we are moving down and we have surpassed the bottom pos.
        {
            body.position = startingPosition + Vector2.down * distance;
            isGoingUp = true;
        }

        body.velocity = new Vector2(body.velocity.x, isGoingUp ? speed : -speed);

    }
}

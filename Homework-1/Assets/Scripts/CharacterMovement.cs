using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float walkStrength = 3;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float velocityX = Input.GetAxis("Horizontal") * walkStrength;
        ApplyHorizontalMovement(velocityX);
        UpdateFacingDirection(velocityX);
    }

    void ApplyHorizontalMovement(float velocityX)
    {
        body.velocity = new Vector2(velocityX, body.velocity.y);
    }

    void UpdateFacingDirection(float velocityX) 
    {
        if (velocityX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(velocityX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // If we are not moving, we should not flip.
    }
}

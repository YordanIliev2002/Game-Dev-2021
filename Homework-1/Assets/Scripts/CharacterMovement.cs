using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float jumpStrength = 8;
    [SerializeField] private float walkStrength = 3;
    private Rigidbody2D body;
    private GroundChecker groundChecker;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        groundChecker = GetComponentInChildren<GroundChecker>();
    }

    void Update()
    {
        float velocityX = Input.GetAxis("Horizontal") * walkStrength;
        ApplyHorizontalMovement(velocityX);
        UpdateFacingDirection(velocityX);

        TryJump();
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

    void TryJump()
    {
        float inputY = Input.GetAxis("Vertical");
        if(inputY > 0 & groundChecker.IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpStrength);
        }
    }
}

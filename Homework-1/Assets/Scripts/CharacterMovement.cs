using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float jumpStrength = 8;
    [SerializeField] private float walkStrength = 3;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Rigidbody2D body;
    private GroundChecker groundChecker;
    private Respawnable respawnable;
    private int countOfJumps = 0;
    private float lastJumpButtonState = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        groundChecker = GetComponentInChildren<GroundChecker>();
        respawnable = GetComponent<Respawnable>();
    }

    void Update()
    {
        if(!respawnable.IsAlive())
        {
            animator?.SetBool("isDead", true);
            return;
        }
        float velocityX = Input.GetAxis("Horizontal") * walkStrength;
        ApplyHorizontalMovement(velocityX);
        UpdateFacingDirection(velocityX);

        TryJump();
        Animate();
    }

    void ApplyHorizontalMovement(float velocityX)
    {
        body.velocity = new Vector2(velocityX, body.velocity.y);
    }

    void UpdateFacingDirection(float velocityX) 
    {
        if (velocityX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(velocityX < 0)
        {
            spriteRenderer.flipX = true;
        }
        // If we are not moving, we should not flip.
    }

    void TryJump()
    {
        float inputY = Input.GetAxisRaw("Vertical");
        if(inputY > 0 & inputY != lastJumpButtonState & countOfJumps < 2)
        {
            countOfJumps++;
            body.velocity = new Vector2(body.velocity.x, jumpStrength);
        }
        else if (inputY < 1 & groundChecker.IsGrounded()) { 
            countOfJumps = 0;
        }
        lastJumpButtonState = inputY;
    }

    public void RegisterArtificialJump()
    {
        countOfJumps = 1;
    }

    void Animate()
    {
        animator?.SetBool("isDead", false);
        animator?.SetBool("isGrounded", groundChecker.IsGrounded());
        animator?.SetFloat("absVelocityX", Mathf.Abs(body.velocity.x));
    }
}

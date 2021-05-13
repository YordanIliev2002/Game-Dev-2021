using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float jumpStrength = 8;
    [SerializeField] private float walkStrength = 3;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private PlayerControls input;
    private Vector2 inputVector = Vector2.zero;

    private Rigidbody2D body;
    private GroundChecker groundChecker;
    private Respawnable respawnable;
    private int countOfJumps = 0;
    private float lastJumpButtonState = 0;
    private bool isMoveInvoked = false;

    private void OnEnable()
    {
        input = new PlayerControls();
        input.Enable();
        input.Player.Movement.started += OnMove;
    }

    private void OnDisable()
    {
        input.Player.Movement.started -= OnMove;
        input.Disable();
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        groundChecker = GetComponentInChildren<GroundChecker>();
        respawnable = GetComponent<Respawnable>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!isMoveInvoked)
        {
            StartCoroutine(Move());
        }
    }

    public IEnumerator Move()
    {
        isMoveInvoked = true;
        do
        {
            inputVector = input.Player.Movement.ReadValue<Vector2>();
            if(respawnable.IsAlive()) // To prevent flipping when the player is dead.
            {
                UpdateFacingDirection(inputVector.x);
            }
            yield return null;
        } while (inputVector.sqrMagnitude > 0);
        isMoveInvoked = false;
        inputVector = Vector2.zero;
    }

    void Update()
    {
        if(!respawnable.IsAlive())
        {
            animator?.SetBool("isDead", true);
            return;
        }

        // Here and not inside Move(), because we want to zero velocity when we are not moving.
        ApplyHorizontalMovement(inputVector.x * walkStrength);
        // Here and not inside Move(), because we want to know when we get grounded(should reset the jump count).
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
            animator?.SetBool("shouldFlip", false);
        }
        else if(velocityX < 0)
        {
            animator?.SetBool("shouldFlip", true);
        }
        // If we are not moving, we should not flip.
    }

    void TryJump()
    {
        if (inputVector.y > 0 & inputVector.y != lastJumpButtonState & countOfJumps < 2)
        {
            countOfJumps++;
            body.velocity = new Vector2(body.velocity.x, jumpStrength);
        }
        else if (inputVector.y < 1 & groundChecker.IsGrounded())
        {
            countOfJumps = 0;
        }
        lastJumpButtonState = inputVector.y;
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

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpPower = 5f;
    private Rigidbody2D rb2d;
    private Animator animator;
    private Vector2 moveInput;
    bool isJumping = false;
    public bool facingRight = true;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isJumping && isGrounded())
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpPower);
            isJumping = false;
            animator.SetBool("IsJumping", true);
        }

        if (isGrounded() && rb2d.linearVelocity.y <= 0.1f)
        {
            animator.SetBool("IsJumping", false);
        }
    }

    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb2d.linearVelocity.y);
        animator.SetFloat("Xvelocity", Math.Abs(rb2d.linearVelocity.x));
        animator.SetFloat("Yvelocity", rb2d.linearVelocity.y);
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        FacingDirection(moveInput);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isJumping = true;
        }
    }

    private void FacingDirection(Vector2 moveInput)
    {

        if (moveInput.x > 0 && !facingRight)
        {
            FlipSprite();

        }
        else if (moveInput.x < 0 && facingRight)
        {
            FlipSprite();

        }
    }

    void FlipSprite()
    {

        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jump = 16f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // الحركة
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        // القفز
        if(Input.GetButtonDown("Jump") && IsGrounded())
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);

        // Flip الشخصية
        Flip();

        // تحديث الأنيميشن
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        animator.SetBool("IsJumping", !IsGrounded());
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if(horizontal > 0)
            sprite.flipX = false;
        else if(horizontal < 0)
            sprite.flipX = true;
    }
}
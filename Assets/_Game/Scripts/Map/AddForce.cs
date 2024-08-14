using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float fallMultiplier = 2.5f; // Multiplier for faster falling
    [SerializeField] private float lowJumpMultiplier = 2f; // Multiplier for shorter jumps
    [SerializeField] private float time;
    [SerializeField] private bool canJump = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }

        if (rb.velocity.y < 0)
        {
            // Apply extra downward force for a faster fall
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            // Apply less upward force for a shorter jump when the player releases the jump button early
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Jump()
    {
        canJump = false;
        rb.velocity = Vector2.up * jumpForce;
        StartCoroutine(EnableJumpAfterDelay());
    }

    private IEnumerator EnableJumpAfterDelay()
    {
        yield return new WaitForSeconds(time); // Delay before allowing the next jump (to avoid double-jumping)
        canJump = true;
    }

/*    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jump ability when touching the ground
        if (collision.gameObject.CompareTag(CacheString.TAG_GROUND))
        {
            canJump = true;
        }
    }*/
}

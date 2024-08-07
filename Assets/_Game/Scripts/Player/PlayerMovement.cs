using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Animator anim;

    [Header("Movement")]
    [SerializeField] private float speed;
    private float dirX = 0f;

    [Header("Player")]
    [SerializeField] private Transform model;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    

    [Header("Jump")]
    // [SerializeField] private float jumpDuration = 0.5f;
    [SerializeField] private float JumpForce = 7.5f;
    [SerializeField] private float distance;
    // private bool isJumping;

    void Update()
    {
        Move();
    }

    public void OnInit()
    {   
        StartCoroutine(ActivePlayerMovement());
    }

    private IEnumerator ActivePlayerMovement()
    {
        // this.enabled = false;
        this.speed = 0f;
        anim.SetTrigger(CacheString.TAG_APPEAR);
        yield return new WaitForSeconds(0.5f);
        // this.enabled = true;
        this.speed = 5f;
        
    }

    private void Move()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        ChangeAnim("IsRunning", dirX != 0 ? true : false);

        if (Mathf.Abs(dirX) > 0.1f)
        {
            model.rotation = Quaternion.Euler(new Vector3(0f, dirX > 0 ? 0f : 180f, 0f));   
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        // Check falling
        if (rb.velocity.y < 0 && !IsGrounded())
        {
            ChangeAnim(CacheString.TAG_ISRUNNING, true);
        }

        if (rb.velocity.y == 0 && IsGrounded())
        {
            ChangeAnim(CacheString.TAG_ISRUNNING, false);
            // isJumping = false;
        }
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            ChangeAnim(CacheString.TAG_ISRUNNING, true);
            // isJumping = true;
        }
    }

    public void ChangeAnim(string currentAnim, bool isActive)
    {
        anim.SetBool(currentAnim, isActive);
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distance, jumpableGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector2.down * distance);
        Gizmos.color = Color.red;
    }
}
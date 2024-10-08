using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public EControlType controlType;
    [SerializeField] private EGravityType gravityType;
    [SerializeField] private EMovementType movementType;

    [Header("Anim")]
    public Animator anim;
    
    [SerializeField] private float speed;
    public float updateSpeed;
    [SerializeField] private bool canJump = true;
    private float dirX = 0f;

    [Header("Player")]
    [SerializeField] private Transform model;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;


    [Header("Jump")]
    public float JumpForce = 7.5f;
    [SerializeField] private float distance;

    void Update()
    {
        Move(controlType);

        this.speed = updateSpeed;
    }

    public void OnInit()
    {   
        StartCoroutine(ActivePlayerMovement());
    }

    private IEnumerator ActivePlayerMovement()
    {
        // this.enabled = false;
        this.speed = 0f;
        if (anim != null)
        {
            anim.SetTrigger(CacheString.TAG_APPEAR);
        }
        yield return new WaitForSeconds(0.5f);
        // this.enabled = true;
        this.speed = updateSpeed;
        
    }

    private void Move(EControlType eControlType)
    {
        dirX = Input.GetAxisRaw("Horizontal");

        switch(eControlType)
        {
            case EControlType.NormalMove:
                //Di chuyen bthg
                if (movementType == EMovementType.None)
                {
                    rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
                }
                
                if (Mathf.Abs(dirX) > 0.1f)
                {
                    model.rotation = Quaternion.Euler(new Vector3(rb.gravityScale < 0 ? 180f : 0f, dirX > 0 ? 0f : 180f, 0f));
                }
                break;
            case EControlType.SpecialMove:
                //Di chuyen nguoc
                rb.velocity = new Vector2(-dirX * speed, rb.velocity.y);
                
                if (Mathf.Abs(dirX) > 0.1f)
                {
                    model.rotation = Quaternion.Euler(new Vector3(rb.gravityScale < 0 ? 180f : 0f, dirX < 0 ? 0f : 180f, 0f));
                }
                break;
        }

        ChangeAnim("IsRunning", dirX != 0 ? true : false);

        if (Input.GetButtonDown("Jump") && IsGrounded() && canJump)
        {
            Jump();
            SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.jump);
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

        if (gravityType == EGravityType.Reverse)
        {
            if (rb.velocity.y > 0 && !IsGrounded())
            {
                ChangeAnim(CacheString.TAG_ISRUNNING, true);
            }
        }
    }

    public void ChangeMoveType()
    {
        if (controlType == EControlType.NormalMove)
        {
            controlType = EControlType.SpecialMove;
            Debug.Log(controlType);
        }
        else if (controlType == EControlType.SpecialMove)
        {
            controlType = EControlType.NormalMove;
            Debug.Log(controlType);
        }
    }

    public void Jump()
    {
        if (gravityType == EGravityType.None)
        {
            if (IsGrounded())
            {
                if (movementType == EMovementType.None)
                {
                    rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                }

                ChangeAnim(CacheString.TAG_ISRUNNING, true);
                // isJumping = true;
            }
        }
        else if (gravityType == EGravityType.Reverse)
        {
            rb.gravityScale = rb.gravityScale * (-1f);
            //Debug.Log(rb.gravityScale);
            model.rotation = Quaternion.Euler(new Vector3(rb.gravityScale < 0 ? 180f : 0f, 0f, 0f));
        }
    }

    public void ChangeAnim(string currentAnim, bool isActive)
    {
        if (anim != null)
        {
            anim.SetBool(currentAnim, isActive);
        }
    }

    private bool IsGrounded()
    {
        //tinh khoang cach theo scale
        float scaledDistance = distance * transform.parent.localScale.y;
        return Physics2D.Raycast(transform.position, rb.gravityScale > 0 ? Vector2.down : Vector2.up, scaledDistance, jumpableGround);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float scaledDistance = distance * transform.parent.localScale.y;
        Vector2 rayDirection = rb.gravityScale > 0 ? Vector2.down : Vector2.up;
        Gizmos.DrawRay(transform.position, rayDirection * scaledDistance);
    }
}

public enum EControlType
{
    NormalMove = 0,
    SpecialMove = 1
}

public enum EGravityType
{
    None = 0,
    Reverse = 1
}

public enum EMovementType
{
    None = 0,
    ConveyorBelt = 1
}
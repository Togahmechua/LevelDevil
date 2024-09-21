using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    [SerializeField] private float strength; 
    [SerializeField] private float maxFallSpeed = -10f;
    [SerializeField] private float maxRiseSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;

    [Header("Anim")]
    [SerializeField] private Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(speed, strength);
            ChangeAnim(CacheString.TAG_ISRUNNING, true);
            SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.jump);
        }

        rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, maxFallSpeed, maxRiseSpeed));
    }

    public void ChangeAnim(string currentAnim, bool isActive)
    {
        if (anim != null)
        {
            anim.SetBool(currentAnim, isActive);
        }
    }
}

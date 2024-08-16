using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float bounce;
    [SerializeField] private Animator anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger(CacheString.TAG_SPRING);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            Observer.Notify("Wait", 0.5f, new Action(()
            => anim.SetTrigger(CacheString.TAG_IDLE)));
        }
    }
}

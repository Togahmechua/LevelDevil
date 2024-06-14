using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform platPos;
    [SerializeField] private BoxCollider2D boxCollider2D;
    private bool isTouching;

    private void Update()
    {
        if (isTouching == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, platPos.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = Cache.GetCharacter(other);
        if(player != null)
        {
            isTouching = true;
            boxCollider2D.enabled = false;
        }
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{
    [SerializeField] private Transform movePos;
    [SerializeField] private float duration;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private bool isTouching;

    private void Update()
    {
        if (isTouching)
        {
            isTouching = false;
        }
        /*DestroyByDistance(transform);*/
    }

    private void MoveCoroutine()
    {
        transform.parent.DOMove(movePos.position, duration);
    }

    private void Move()
    {
        if (transform.parent == null)
        {
            Debug.LogWarning("Parent Transform is null or destroyed");
            return;
        }
        transform.parent.DOMove(movePos.position, duration);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = Cache.GetCharacter(other);
        if (player != null)
        {
            box.enabled = false;
            isTouching = true;
            Move();
        }
    }
}

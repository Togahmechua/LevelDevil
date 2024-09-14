using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FlappyButton : MonoBehaviour
{
    [Header("Box")]
    [SerializeField] private SpriteRenderer btnSprite;
    [SerializeField] private Sprite spr;
    [SerializeField] private BoxCollider2D box;

    [Header("FixMoveDetails")]
    [SerializeField] private FlappyMovement flappyMovement;
    [SerializeField] private Transform model;
    [SerializeField] private float speed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = Cache.GetCharacter(other);
        if (player != null)
        {
            box.enabled = false;
            btnSprite.sprite = spr;
            flappyMovement.speed = this.speed;
            if (Mathf.Abs(flappyMovement.speed) > 0.1f)
            {
                model.rotation = Quaternion.Euler(new Vector3(0f, flappyMovement.speed > 0 ? 0f : 180f, 0f));
            }
        }
    }
}

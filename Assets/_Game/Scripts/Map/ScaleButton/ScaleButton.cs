using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class ScaleButton : MonoBehaviour
{
    [SerializeField] private SpriteRenderer btnSprite;
    [SerializeField] private Sprite spr;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private PlayerCtrl playerCtrl;
    [SerializeField] private Vector3 scaleSize;
    [SerializeField] private float duration;

    [Header("Player Config")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    
    private void ScalePlayer()
    {
        if (playerCtrl != null)
        {
            // Kill any existing scaling tweens on the player
            playerCtrl.transform.DOKill();

            // Start the new scaling tween
            playerCtrl.transform.DOScale(scaleSize, duration);
        }
        else
        {
            Debug.Log("PlayerCtrl is null");
        }
    }

    private void SetPlayerDetails(float playerSpeed, float playerJumpForce)
    {
        if (playerCtrl != null)
        {
            playerCtrl.playerMovement.updateSpeed = playerSpeed;
            playerCtrl.playerMovement.JumpForce = playerJumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = Cache.GetCharacter(other);
        if (player != null)
        {
            playerCtrl = player;
            box.enabled = false;
            btnSprite.sprite = spr;
            ScalePlayer();
            SetPlayerDetails(speed, jumpForce);
        }
    }
}

public enum EScale
{
    Bigger = 0,
    Smaller = 1
}
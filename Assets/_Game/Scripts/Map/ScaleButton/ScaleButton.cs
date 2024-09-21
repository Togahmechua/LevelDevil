using DG.Tweening;
using EZCameraShake;
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

    [Header("BtnType")]
    [SerializeField] private EShakeBtn shakeBtnType;
    [SerializeField] private float magnitude, roughness, fadeInTime;
    [SerializeField] private float delay;
    private CameraShakeInstance shakeInstance;


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
            SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.button);

            ScalePlayer();
            SetPlayerDetails(speed, jumpForce);

            if (shakeBtnType == EShakeBtn.Special)
            {
                StopCameraShake(); // Stop current shake before starting a new one

                Sequence mySequence = DOTween.Sequence();
                mySequence.AppendCallback(() =>
                {
                    // Start a new camera shake
                    shakeInstance = CameraShaker.Instance.StartShake(magnitude, roughness, fadeInTime);
                    LevelManager.Ins.endShakingScence = true;
                });
                mySequence.AppendInterval(delay);
                mySequence.AppendCallback(() =>
                {
                    StopCameraShake();
                });
                mySequence.Play();
            }
        }
    }

    public void StopCameraShake()
    {
        if (shakeInstance != null)
        {
            shakeInstance.CancelShake();
            shakeInstance = null;
        }
    }
}

public enum EScale
{
    Bigger = 0,
    Smaller = 1
}

public enum EShakeBtn
{
    Normal = 0,
    Special = 1
}

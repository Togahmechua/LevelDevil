using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Transform platPos;
    [SerializeField] private EMove moveType;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private bool isTouching;
    [SerializeField] private bool flag;

    private void Update()
    {
        if (isTouching == true)
        {
            MoveObj(moveType);
        }
    }

    private void MoveObj(EMove moveType)
    {
        switch (moveType)
        {
            case EMove.NormalMove:
                transform.DOMove(platPos.position, duration);
                if(!flag)
                {
                    SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.walltrap);
                    flag = true;
                }
                break;
            case EMove.LocalMove:
                transform.DOLocalMove(platPos.position, duration);
                if (!flag)
                {
                    SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.walltrap);
                    flag = true;
                }
                break;
            default:
                Debug.Log("Nothing");
                break;
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

public enum EMove
{
    NormalMove = 0,
    LocalMove = 1,
    StepByStepMove = 2
}

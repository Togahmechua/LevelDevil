using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{
    [SerializeField] private Transform gameObj;
    [SerializeField] private Transform movePos;
    [SerializeField] private float duration;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private bool isTouching;
    [SerializeField] private EMovingOBJType EMovingOBJType;
    [SerializeField] private EBox EBox;
    [SerializeField] private ESaw ESaw;
    [SerializeField] private bool flag;

    private Saw saw;

    private void Start()
    {
        if (gameObj != null)
        {
            saw = gameObj.GetComponentInChildren<Saw>();
            if (saw != null)
            {
                Debug.Log("Saw component found.");
            }
            else
            {
                Debug.LogWarning("Saw component not found.");
            }
        }
    }

    private void Update()
    {
        if (gameObj == null && EMovingOBJType == EMovingOBJType.MovingGameObj)
        {
            Debug.LogError("Game obj is not exist");
        }

        if (isTouching)
        {
            isTouching = false;
        }
        /*DestroyByDistance(transform);*/
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
            switch (EBox)
            {
                case EBox.BoxEnableFalse:
                    box.enabled = false;
                    isTouching = true;
                    break;
                case EBox.BoxEnableTrue:
                    box.enabled = true;
                    isTouching = true;
                    break;
            }

            switch (ESaw)
            {
                case ESaw.ActiveSaw:
                    if (saw != null)
                    {
                        saw.isAbleToMove = false;
                    }
                    break;
                case ESaw.DeActiveSaw:
                    if (saw != null)
                    {
                        Sequence mySequence = DOTween.Sequence();
                        mySequence.AppendInterval(0.5f);
                        mySequence.AppendCallback(() =>
                        {
                            saw.isAbleToMove = true;
                            gameObj.DOMove(movePos.position, duration);
                        });
                        mySequence.Play();
                    }
                    break;
            }

            switch (EMovingOBJType)
            {
                case EMovingOBJType.MovingParent:
                    Move();
                    if (!flag)
                    {
                        SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.walltrap);
                        flag = true;
                    }
                    break;
                case EMovingOBJType.MovingGameObj:
                    gameObj.DOMove(movePos.position, duration);
                    if (!flag)
                    {
                        SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.walltrap);
                        flag = true;
                    }
                    break;
            }     
        }
    }
}

public enum EMovingOBJType
{
    MovingParent = 0,
    MovingGameObj = 1
}

public enum EBox
{
   BoxEnableFalse = 0,
   BoxEnableTrue = 1
}

public enum ESaw
{
    ActiveSaw = 0,
    DeActiveSaw = 1
}

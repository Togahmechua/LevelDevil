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
            

            switch (EMovingOBJType)
            {
                case EMovingOBJType.MovingParent:
                    Move();
                    break;
                case EMovingOBJType.MovingGameObj:
                    gameObj.DOMove(movePos.position, duration);
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

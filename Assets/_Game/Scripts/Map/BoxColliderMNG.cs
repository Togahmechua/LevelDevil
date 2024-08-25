using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class BoxColliderMNG : MonoBehaviour
{
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private int count;
    [SerializeField] private Transform movePosMNG;
    [SerializeField] private List<MoveAtion> moveAtions = new List<MoveAtion>();

    [Serializable]
    public class MoveAtion
    {
        public Transform gameObj;
        public Transform movePos;
        public float duration;

        public void DoSmth()
        {
            gameObj.DOMove(movePos.position, duration);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = Cache.GetCharacter(other);
        if (player != null)
        {
            if (count >= 0 && count < moveAtions.Count)
            {
                moveAtions[count].DoSmth();
                count++;
            }
            else
            {
                Debug.LogWarning("Count is out of range, cannot perform DoSmth.");
            }
            
            if (count >= moveAtions.Count)
            {
                box.enabled = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (movePosMNG != null)
        {
            for (int i = 0; i < moveAtions.Count; i++)
            {
                if (movePosMNG.childCount > moveAtions.Count)
                {
                    Debug.LogError("Out of ray");
                }
                moveAtions[i].movePos = movePosMNG.GetChild(i);
            }
        }
    }
}

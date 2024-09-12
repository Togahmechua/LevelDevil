using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOtherObj : MonoBehaviour
{
    [SerializeField] private List<OtherObjDetails> otherObjDetails = new List<OtherObjDetails>();
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private Saw saw;
    [SerializeField] private float delay;

    [Serializable]
    public class OtherObjDetails
    {
        public Vector3 scaleOther;
        public float duration;

        public float rotateSpeed;
        public Vector3 waypoints;
        public float durationToChangeWP;
    }

    private void ScaleOther(int currentIndex = 0)
    {
        if (saw != null && otherObjDetails.Count > 0 && currentIndex < otherObjDetails.Count)
        {
            saw.PauseMovement();

            Sequence mySequence = DOTween.Sequence();
            saw.isAbleToMove = true;
            mySequence.AppendInterval(delay);
            mySequence.AppendCallback(() =>
            {
                saw.transform.DOScale(otherObjDetails[currentIndex].scaleOther, otherObjDetails[currentIndex].duration).OnComplete(() =>
                {
                    
                    saw.transform.DOMove(otherObjDetails[currentIndex].waypoints, otherObjDetails[currentIndex].durationToChangeWP).OnComplete(() =>
                    {
                        if (Vector2.Distance(saw.transform.position, otherObjDetails[currentIndex].waypoints) < 0.1f)
                        {
                            currentIndex++;
                            if (currentIndex < otherObjDetails.Count)
                            {
                                ScaleOther(currentIndex);
                            }
                        }
                    });
                });
            });

            mySequence.Play();
        }
        else
        {
            Debug.LogWarning("saw is null or otherObjDetails is empty.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = Cache.GetCharacter(other);
        if (player != null)
        {
            box.enabled = false;
            ScaleOther();
        }
    }
}

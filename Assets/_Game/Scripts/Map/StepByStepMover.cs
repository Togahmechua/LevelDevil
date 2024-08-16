using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class StepByStepMover : MonoBehaviour
{
    [SerializeField] private List<MoveAction> moveActions = new List<MoveAction>();
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private Transform movingObj;
    [SerializeField] private EDeActiveBox eDeactiveBox;
    private int currentActionIndex = 0;
    private bool isMoving = false;

    public void DoMove()
    {
        isMoving = true;
        StartCoroutine(MoveToPositions());
    }

    [Serializable]
    public class MoveAction
    {
        public Transform movePos;
        public float speed;
        public float duration;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl playerCtrl = Cache.GetCharacter(other);
        if (playerCtrl != null && !isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveToPositions());

            switch(eDeactiveBox)
            {
                case EDeActiveBox.DeActive:
                    box.enabled = false;
                    break;
                case EDeActiveBox.Active:
                    box.enabled = true;
                    break;
            }
        }
    }

    private IEnumerator MoveToPositions()
    {
        while (currentActionIndex < moveActions.Count)
        {
            MoveAction action = moveActions[currentActionIndex];
            yield return StartCoroutine(MoveToPosition(action.movePos.position, action.speed));
            yield return new WaitForSeconds(action.duration);

            currentActionIndex++;
        }

        isMoving = false;
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition, float speed)
    {
        Vector3 startPosition = movingObj.position; // Sử dụng vị trí của movingObj thay vì transform
        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        while (Vector3.Distance(movingObj.position, targetPosition) > 0.01f) // Điều kiện kiểm tra khi còn khoảng cách nhỏ đến vị trí đích
        {
            // Khoảng cách mà đối tượng đã di chuyển tính từ điểm bắt đầu.
            float distanceCovered = (Time.time - startTime) * speed;
            // Tỷ lệ của khoảng cách hành trình đã hoàn thành, dựa trên tổng khoảng cách (journeyLength).
            float fractionOfJourney = distanceCovered / journeyLength;
            movingObj.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            yield return null;
        }

        // Đảm bảo đối tượng đạt chính xác vị trí đích sau khi hoàn thành việc di chuyển
        movingObj.position = targetPosition;
    }
}

public enum EDeActiveBox
{
    DeActive = 0,
    Active = 1
}

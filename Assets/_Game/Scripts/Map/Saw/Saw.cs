using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(CircleCollider2D))]
public class Saw : Spikes
{
    public SawDetails sawDetails;
    public bool isAbleToMove;

    [SerializeField] private Transform saw;

    [Serializable]
    public class SawDetails
    {
        public float rotateSpeed;
        public List<Transform> waypoints;
        public float duration;
        [HideInInspector] public int currentWaypointIndex = 0;
    }

    private void Start()
    {
        RestartMovement();
    }

    public void RestartMovement()
    {
        sawDetails.currentWaypointIndex = 0;
        MoveToNextWaypoint(sawDetails);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * sawDetails.rotateSpeed * Time.deltaTime);
    }

    public void PauseMovement()
    {
        DOTween.Pause(this);
    }

    public void ResumeMovement()
    {
        DOTween.Play(this);  
    }

    private void MoveToNextWaypoint(SawDetails sawDetail)
    {
        if (isAbleToMove == true)
        {
            return;
        }

        if (sawDetail.waypoints.Count == 0) return;

        Transform targetWaypoint = sawDetail.waypoints[sawDetail.currentWaypointIndex];

        saw.DOMove(targetWaypoint.position, sawDetail.duration).SetEase(Ease.Linear).SetId(this).OnComplete(() =>
        {
           sawDetail.currentWaypointIndex++;
           if (sawDetail.currentWaypointIndex >= sawDetail.waypoints.Count)
           {
               sawDetail.currentWaypointIndex = 0;
           }
           MoveToNextWaypoint(sawDetail);
        });
    }
}

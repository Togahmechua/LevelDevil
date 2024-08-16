using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveWithDelay : MonoBehaviour
{
    [SerializeField] private List<Platform> plList = new List<Platform>();
    [SerializeField] private BoxCollider2D box;

    [Serializable]
    public class Platform
    {
        public StepByStepMover gameObj;
        public float delay;
    }

    private void Move()
    {
        for (int i = 0; i < plList.Count; i++)
        {
            int index = i;  // Sử dụng biến tạm thời để giữ giá trị của i
            Platform plat = plList[index];
            Sequence sequence = DOTween.Sequence();
            sequence.AppendCallback(() => plat.gameObj.DoMove())
                    .SetDelay(plat.delay);
                        
            sequence.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = Cache.GetCharacter(other);

        if (player != null)
        {
            box.enabled = false;
            Move();
        }
    }
}

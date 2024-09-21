using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class ActiveWave : MonoBehaviour
{
    [SerializeField] private List<Transform> listSpike = new List<Transform>();
    [SerializeField] private Transform child;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private EType type;
    [SerializeField] private float despawnDelay = 1.0f; // Thời gian chờ trước khi despawn

    private void CreateWave()
    {
        float delayBetweenItems = 0.15f; // Độ trễ giữa các phần tử

        for (int i = 0; i < child.childCount; i++)
        {
            int index = i;  // Sử dụng biến tạm thời để giữ giá trị của i
            Transform spike = listSpike[index];

            // Tạo chuỗi Tweening cho từng phần tử
            Sequence waveSequence = DOTween.Sequence();
            waveSequence.AppendCallback(() => 
            {
                spike.gameObject.SetActive(true);
                SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.walltrap);
            })
                        .SetDelay(index * delayBetweenItems);

            waveSequence.Play();
        }
    }

    private void DespawnWave()
    {
        float delayBetweenItems = 0.15f; // Độ trễ giữa các phần tử

        for (int i = 0; i < child.childCount; i++)
        {
            int index = i;  // Sử dụng biến tạm thời để giữ giá trị của i
            Transform spike = listSpike[index];

            // Tạo chuỗi Tweening cho từng phần tử
            Sequence waveSequence = DOTween.Sequence();
            waveSequence.AppendInterval(despawnDelay); // Thêm thời gian chờ trước khi despawn
            waveSequence.AppendCallback(() => spike.gameObject.SetActive(false))
                        .SetDelay(index * delayBetweenItems);

            waveSequence.Play();
        }
    }

    private void CreateWaveType(EType eType)
    {
        switch (eType)
        {
            case EType.CreateWave:
                CreateWave();
                break;
            case EType.DespawWaveAfterCreate:
                CreateWave();
                Observer.Notify("Wait", 1f, new Action(DespawnWave));
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = Cache.GetCharacter(other);

        if (player != null)
        {
            box.enabled = false;
            CreateWaveType(type);
        }
    }

    private void OnDrawGizmosSelected()
    {
        listSpike.Clear();
        for (int i = 0; i < child.childCount; i++)
        {
            listSpike.Add(child.GetChild(i));
        }
    }
}

public enum EType
{
    CreateWave = 0,
    DespawWaveAfterCreate = 1
}

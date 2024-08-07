using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoxHolder : MonoBehaviour
{
    [SerializeField] private List<Transform> listBox = new List<Transform>();
    [SerializeField] private int curLevel;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        OnInit();
        CreateWaveEffect();
    }

    private void CreateWaveEffect()
    {
        float delayBetweenItems = 0.2f; // Độ trễ giữa các phần tử
        float scaleUpDuration = 0.5f;   // Thời gian phóng to
        float scaleDownDuration = 0.5f; // Thời gian thu nhỏ

        for (int i = 0; i <= curLevel; i++)
        {
            int index = i;  // Sử dụng biến tạm thời để giữ giá trị của i
            Transform box = listBox[index];

            // Tạo chuỗi Tweening cho từng phần tử
            Sequence waveSequence = DOTween.Sequence();
            waveSequence.Append(box.DOScale(new Vector3(0.7f, 0.7f, 0.7f), scaleUpDuration))
                        .Append(box.DOScale(new Vector3(0.4f, 0.4f, 0.4f), scaleDownDuration))
                        .SetDelay(index * delayBetweenItems);

            waveSequence.Play();
        }
    }

    private void OnInit()
    {
        for (int i = 0; i <= curLevel && i < listBox.Count; i++)
        {
            Transform t = listBox[i];
            spriteRenderer = t.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                t.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning($"SpriteRenderer không tìm thấy trong {t.name}");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        listBox.Clear();
        for (int i = 1; i < this.transform.childCount; i++)
        {
            listBox.Add(this.transform.GetChild(i));
        }
    }
}

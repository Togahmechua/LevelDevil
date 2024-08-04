using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscCanvasUI : UICanvas
{
    [SerializeField] private Button escBut;   
    [SerializeField] private Image escImg;
    [SerializeField] private Sprite[] ecsSpr;

    void Start()
    {
        escBut.onClick.AddListener(EscFunc);
        escImg.sprite = ecsSpr[0];
    }

    private void EscFunc()
    {
        escImg.sprite = ecsSpr[1];
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(0.5f);
        mySequence.AppendCallback(() =>
        {
            escImg.sprite = ecsSpr[0];
            UIManager.Ins.OpenUI<SelectLevelUI>();
            UIManager.Ins.OpenUI<AnimCanvas2>().OnInit2();
        });
    }
}

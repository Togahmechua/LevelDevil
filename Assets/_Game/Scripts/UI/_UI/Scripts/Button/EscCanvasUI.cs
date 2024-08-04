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

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            EscFunc();
            /*Cursor.visible = false;*/
        }
    }

    private void EscFunc()
    {
        escImg.sprite = ecsSpr[1];
        UIManager.Ins.OpenUI<AnimCanvas2>().OnInit2();
        Observer.Notify("Wait", 1f, new Action(NextUI));
    }


    private void NextUI()
    {
        escImg.sprite = ecsSpr[0];
        UIManager.Ins.OpenUI<SelectLevelUI>();
        UIManager.Ins.OpenUI<CursorCanvas>();
        UIManager.Ins.CloseUI<EscCanvasUI>();
    }
}

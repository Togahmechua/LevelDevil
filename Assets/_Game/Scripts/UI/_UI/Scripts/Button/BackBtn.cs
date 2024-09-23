using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackBtn : MonoBehaviour
{
    [SerializeField] private Button backBut;
    [SerializeField] private Image backImg;
    [SerializeField] private Sprite[] backSpr;

    void Start()
    {
        backBut.onClick.AddListener(SettingFunc);
        OnInit();
    }

    public void OnInit()
    {
        backImg.sprite = backSpr[0];
        DisableInteractionForSeconds(1f);
    }

    private void SettingFunc()
    {
        SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.button);
        backImg.sprite = backSpr[1];
        UIManager.Ins.OpenUI<AnimCanvas2>().OnInit2();
        Observer.Notify("Wait", 1f, new Action(NextUI));
    }

    private void DisableInteractionForSeconds(float seconds)
    {
        backBut.interactable = false;
        DOVirtual.DelayedCall(seconds, () =>
        {
            backBut.interactable = true;
        });
    }

    private void NextUI()
    {
        Debug.Log("NextUI");
        backImg.sprite = backSpr[0];
        UIManager.Ins.CloseUI<SettingCanvas>();
        UIManager.Ins.OpenUI<SelectLevelUI>();
    }
}

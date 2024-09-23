using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingBtn : MonoBehaviour
{
    [SerializeField] private Button settingBut;
    [SerializeField] private Image settingImg;
    [SerializeField] private Sprite[] settingSpr;

    void Start()
    {
        settingBut.onClick.AddListener(SettingFunc);
        settingImg.sprite = settingSpr[0];
        DisableInteractionForSeconds(1f);
    }

    private void SettingFunc()
    {
        SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.button);
        settingImg.sprite = settingSpr[1];
        UIManager.Ins.OpenUI<AnimCanvas2>().OnInit2();
        Observer.Notify("Wait", 1f, new Action(NextUI));
    }

    private void DisableInteractionForSeconds(float seconds)
    {
        settingBut.interactable = false;
        DOVirtual.DelayedCall(seconds, () =>
        {
            settingBut.interactable = true;
        });
    }

    private void NextUI()
    {
        Debug.Log("NextUI");
        settingImg.sprite = settingSpr[0];
        UIManager.Ins.CloseUI<SelectLevelUI>();
        UIManager.Ins.OpenUI<SettingCanvas>();
    }
}

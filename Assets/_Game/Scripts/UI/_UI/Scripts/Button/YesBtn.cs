using DG.Tweening;
using EZCameraShake;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesBtn : MonoBehaviour
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

        // Mở giao diện mới
        UIManager.Ins.OpenUI<AnimCanvas2>().OnInit2();
        StartCoroutine(NextUI());
    }

    private void DisableInteractionForSeconds(float seconds)
    {
        settingBut.interactable = false;
        DOVirtual.DelayedCall(seconds, () =>
        {
            settingBut.interactable = true;
        });
    }

    private IEnumerator NextUI()
    {
        yield return new WaitForSeconds(0.5f);
        settingImg.sprite = settingSpr[0];
        PlayerPrefs.DeleteAll();
        Debug.Log("Delete All");

        yield return new WaitForSeconds(0.5f);

        // Đóng và mở UI sau khi hoàn thành
        UIManager.Ins.CloseUI<SettingCanvas>();
        UIManager.Ins.OpenUI<SelectLevelUI>();
    }
}

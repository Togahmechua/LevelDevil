using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteData : MonoBehaviour
{
    [SerializeField] private Button deleteBut;
    [SerializeField] private Image deleteImg;
    [SerializeField] private Sprite[] deleteSpr;
    [SerializeField] private Button yesBtn;

    void Start()
    {
        deleteBut.onClick.AddListener(SettingFunc);
        OnInit();
    }

    public void OnInit()
    {
        this.gameObject.SetActive(true);
        deleteImg.sprite = deleteSpr[0];
        DisableInteractionForSeconds(1f);
        yesBtn.gameObject.SetActive(false);
    }

    private void SettingFunc()
    {
        SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.button);
        this.gameObject.SetActive(false);
        yesBtn.gameObject.SetActive(true);
    }

    private void DisableInteractionForSeconds(float seconds)
    {
        deleteBut.interactable = false;
        DOVirtual.DelayedCall(seconds, () =>
        {
            deleteBut.interactable = true;
        });
    }
}

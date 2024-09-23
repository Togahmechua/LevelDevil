using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundBtn : MonoBehaviour
{
    [SerializeField] private Button soundBut;
    [SerializeField] private Image soundImg;
    [SerializeField] private Sprite[] soundSpr;
    [SerializeField] private bool isOff;

    void Start()
    {
        soundBut.onClick.AddListener(SettingFunc);
        OnInit();
    }

    public void OnInit()
    {
        DisableInteractionForSeconds(1f);
        soundImg.sprite = soundSpr[isOff ? 1 : 0];
    }

    private void SettingFunc()
    {
        SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.button);
        isOff = !isOff;
        soundImg.sprite = soundSpr[isOff ? 1 : 0];
        InteractBtn();
    }

    private void DisableInteractionForSeconds(float seconds)
    {
        soundBut.interactable = false;
        DOVirtual.DelayedCall(seconds, () =>
        {
            soundBut.interactable = true;
        });
    }

    private void InteractBtn()
    {
        if (isOff)
        {
            SoundFXMNG.Ins.SFXSource.volume = 0f;
        }
        else
        {
            SoundFXMNG.Ins.SFXSource.volume = 0.5f;
        }
    }
}

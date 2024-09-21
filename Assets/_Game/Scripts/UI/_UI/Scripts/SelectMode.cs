using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMode : UICanvas
{
    [SerializeField] private Button singleMode;
    /*[SerializeField] private Button multiMode;*/

    void Start()
    {
        singleMode.onClick.AddListener(SelectModeUI);
    }

    private void SelectModeUI()
    { 
        UIManager.Ins.OpenUI<AnimCanvas2>();
        SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.button);
        Observer.Notify("Wait", 1f, new Action(NextUI));
    }

    private void NextUI()
    {
        UIManager.Ins.OpenUI<SelectLevelUI>();
        UIManager.Ins.CloseUI<SelectMode>();
    }
}

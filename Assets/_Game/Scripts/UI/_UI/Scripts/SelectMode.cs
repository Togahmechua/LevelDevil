using DG.Tweening;
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
        singleMode.interactable = false;
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(0.1f);
        sequence.AppendCallback(() =>
        {
            singleMode.interactable = true;
            /*multiMode.onClick.AddListener(SelectModeUI);*/
        });
        
    }

    private void SelectModeUI()
    {
        UIManager.Ins.CloseUI<SelectMode>();
        UIManager.Ins.OpenUI<SelectLevelUI>();
        UIManager.Ins.OpenUI<AnimCanvas2>().OnInit2();
    }
}

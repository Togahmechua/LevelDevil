using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : UICanvas
{
    public Image image;
    public float fillDuration = 2f; // Thời gian để thanh đầy (giây)

    private void Start()
    {
        image.fillAmount = 0;
        FillBar();
    }

    private void Update()
    {
        FillBar();
    }

    private void FillBar()
    {
        image.DOFillAmount(1, fillDuration).OnComplete(() =>
        {
            UIManager.Ins.OpenUI<CursorCanvas>();
            UIManager.Ins.OpenUI<SelectMode>();
            UIManager.Ins.OpenUI<AnimCanvas>();
            UIManager.Ins.CloseUI<StartScene>();
        });
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCanvas : UICanvas
{
    private void Start()
    {
        Wait();
    }

    public void Wait()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(2f);
        mySequence.AppendCallback(() =>
        {
            UIManager.Ins.CloseUI<AnimCanvas>();
        });
    }
}

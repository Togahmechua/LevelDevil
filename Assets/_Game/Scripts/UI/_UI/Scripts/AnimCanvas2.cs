using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCanvas2 : UICanvas
{
    private void Start()
    {
        OnInit2();
    }

    public void OnInit2()
    {
        Wait();
    }

    protected virtual void DoAction()
    {
        //For override
    }

    public void Wait()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(2f);
        mySequence.AppendCallback(() =>
        {
            UIManager.Ins.CloseUI<AnimCanvas2>();
        });
        mySequence.Play();
    }
}

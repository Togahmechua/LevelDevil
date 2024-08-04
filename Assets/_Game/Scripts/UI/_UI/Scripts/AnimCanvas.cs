using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCanvas : UICanvas
{
    private void Start()
    {
        OnInit1();
    }

    public void OnInit1()
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
            UIManager.Ins.CloseUI<AnimCanvas>();
        });
        mySequence.Play();
    }
}

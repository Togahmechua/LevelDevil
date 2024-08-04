using DG.Tweening;
using System;
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
        Observer.Notify("Wait", 2f, new Action(CloseUI));
    }

    private void CloseUI()
    {
        UIManager.Ins.CloseUI<AnimCanvas2>();
        //Debug.Log("AnimCanvas2");
    }
}

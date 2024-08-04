using DG.Tweening;
using System;
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
        Observer.Notify("Wait", 2f, new Action(CloseUI));
    }

    private void CloseUI()
    {
        UIManager.Ins.CloseUI<AnimCanvas>();
        //Debug.Log("AnimCanvas");
    }
}

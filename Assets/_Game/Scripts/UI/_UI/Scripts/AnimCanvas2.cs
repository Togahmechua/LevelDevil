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
        DoAction();
        Wait();
    }

    protected virtual void DoAction()
    {
        StartCoroutine(SoundEff());
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

    private IEnumerator SoundEff()
    {
        yield return new WaitForSeconds(0.2f);
        SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.outtro);
    }
}

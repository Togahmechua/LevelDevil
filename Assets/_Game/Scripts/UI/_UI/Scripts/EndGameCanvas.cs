using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCanvas : UICanvas
{
    public Animator anim;

    public void Blink()
    {
        anim.SetTrigger(CacheString.TAG_BLINK);
    }
}

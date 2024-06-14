using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl playerCtrl = Cache.GetCharacter(other);
        if (playerCtrl != null)
        {
            anim.SetTrigger(CacheString.TAG_WIN);
        }
    }
}

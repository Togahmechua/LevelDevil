using EZCameraShake;
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
            other.gameObject.SetActive(false);
            CameraShaker.Instance.ShakeOnce(2f, 2f, 0.1f, 0.1f);
            if (anim != null)
            {
                anim.SetTrigger(CacheString.TAG_WIN);
                Debug.Log("Anim is missing or null");
            }
        }
    }
}

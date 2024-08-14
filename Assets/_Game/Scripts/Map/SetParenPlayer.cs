using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParenPlayer : MonoBehaviour
{
    [SerializeField] private Level level;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl playerCtrl = Cache.GetCharacter(other);
        if (playerCtrl != null && playerCtrl.gameObject.activeInHierarchy)
        {
            playerCtrl.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerCtrl playerCtrl = Cache.GetCharacter(other);
        if (playerCtrl != null && playerCtrl.gameObject.activeInHierarchy)
        {
            playerCtrl.transform.SetParent(level.transform);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveGOBJ : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private BoxCollider2D box;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = Cache.GetCharacter(other);
        if (player != null)
        {
            obj.SetActive(true);
            box.enabled = false;
        }
    }
}

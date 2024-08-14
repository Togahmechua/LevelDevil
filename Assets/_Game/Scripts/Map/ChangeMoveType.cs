using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMoveType : MonoBehaviour
{
    [SerializeField] private BoxCollider2D box;

    public void DeactiveBox()
    {
        box.enabled = false;
    }
}

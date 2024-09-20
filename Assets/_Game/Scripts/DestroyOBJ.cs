using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOBJ : MonoBehaviour
{
    [SerializeField] protected float deadZone;
    public bool isDed;

    protected virtual void DestroyByDistance(Transform other)
    {
        if (other.position.y < deadZone)
        {
            other.gameObject.SetActive(false);
        }
    }

    protected virtual void DestroyByDistance(PlayerCtrl other)
    {
        if (other.gameObject.transform.position.y < deadZone)
        {
            LevelManager.Ins.WaitForPlayerInputToRestart();
            isDed = true;
        }
    }
}

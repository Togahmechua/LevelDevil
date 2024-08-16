using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveGOBJ : MonoBehaviour
{
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private List<ObjList> listObj;
    [SerializeField] private EActiveType etype;

    [Serializable]
    public class ObjList
    {
        public GameObject obj;
        public float delayTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = Cache.GetCharacter(other);
        if (player != null)
        {
            StartCoroutine(WaitDelayTime());
        }
    }

    private IEnumerator WaitDelayTime()
    {
        switch (etype)
        {
            case EActiveType.Active:
                foreach (ObjList item in listObj)
                {
                    yield return new WaitForSeconds(item.delayTime);
                    item.obj.SetActive(true);
                }
                box.enabled = false;
                break;
            case EActiveType.DeActive:
                foreach (ObjList item in listObj)
                {
                    yield return new WaitForSeconds(item.delayTime);
                    item.obj.SetActive(false);
                }
                box.enabled = false;
                break;
        }
        
    }
}


public enum EActiveType
{
    Active = 0,
    DeActive = 1
}

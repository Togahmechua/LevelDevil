using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveGOBJ : MonoBehaviour
{
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private List<ObjList> listObj;
    [SerializeField] private ESetActiveType etype;
    [SerializeField] private EDeActiveBox eDeActiveBox;

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
            case ESetActiveType.Active:
                foreach (ObjList item in listObj)
                {
                    yield return new WaitForSeconds(item.delayTime);
                    item.obj.SetActive(true);
                }

                if (eDeActiveBox == EDeActiveBox.DeActive)
                {  
                    box.enabled = false;
                }
                else if (eDeActiveBox == EDeActiveBox.Active)
                {
                    box.enabled = true;
                }
                break;
            case ESetActiveType.DeActive:
                foreach (ObjList item in listObj)
                {
                    yield return new WaitForSeconds(item.delayTime);
                    item.obj.SetActive(false);
                }

                if (eDeActiveBox == EDeActiveBox.DeActive)
                {
                    box.enabled = false;
                }
                else if (eDeActiveBox == EDeActiveBox.Active)
                {
                    box.enabled = true;
                }
                break;
        }
        
    }
}


public enum ESetActiveType
{
    Active = 0,
    DeActive = 1
}


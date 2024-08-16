using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
    [SerializeField] private ERotate eRotate;
    [SerializeField] private float rotationSpeed = 0f;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private bool canRotate;
    [SerializeField] private List<Transform> transList = new List<Transform>();

    private void Update()
    {
        if (canRotate == true)
        {
            RotateObj();
        }
    }

    private void RotateObj()
    {
        switch(eRotate)
        {
            case ERotate.RotateTo90:
                rotationSpeed += 100 * Time.deltaTime;
                if (rotationSpeed >= 90)
                {
                    rotationSpeed = 90f;
                    canRotate = false;
                }

                foreach (Transform child in transList)
                {
                    child.rotation = Quaternion.Euler(0, rotationSpeed, 0);
                }

                break;
            case ERotate.RotateTo0:
                rotationSpeed -= 100 * Time.deltaTime;
                if (rotationSpeed <= 0)
                {
                    rotationSpeed = 0f;
                    canRotate = false;
                }

                foreach (Transform child in transList)
                {
                    child.rotation = Quaternion.Euler(0, rotationSpeed, 0);
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl playerCtrl = Cache.GetCharacter(other);
        if (playerCtrl != null)
        {
            canRotate = true;
            box.enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        transList.Clear();
        for (int i = 0;i <= this.transform.childCount - 1;i++)
        {
            transList.Add(transform.GetChild(i));
        }
    }
}

public enum ERotate
{
    RotateTo90 = 0,
    RotateTo0 = 1
}

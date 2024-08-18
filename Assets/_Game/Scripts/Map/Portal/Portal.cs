using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private List<Transform> telePosList = new List<Transform>();
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Transform child;
    [SerializeField] private int count;
    [SerializeField] private int max;

    private void Start()
    {
        max = telePosList.Count;
        if (child == null)
        {
            Debug.Log("child == null");
        }
    }

    private void Update()
    {
        if (count >= max)
        {
            boxCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = Cache.GetCharacter(other);
        if (player != null )
        {
            player.transform.position = telePosList[count].position;

            count++;
        }
    }

    private void OnDrawGizmosSelected()
    {
        telePosList.Clear();
        for (int i = 0; i < child.childCount; i++)
        {
            telePosList.Add(child.GetChild(i));
        }

        max = telePosList.Count;
        Debug.Log(max);
    }
}

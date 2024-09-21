using System;
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
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerCtrl player;
    [SerializeField] private bool isDeactiveBox;

    private void Start()
    {
        max = telePosList.Count;
        if (child == null)
        {
            Debug.Log("child == null");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl playerCtrl = Cache.GetCharacter(other);
        if (playerCtrl != null )
        {
            rb = playerCtrl.GetComponent<Rigidbody2D>();
            player = playerCtrl;

            SoundFXMNG.Ins.PlaySFX(SoundFXMNG.Ins.revive);
            StartCoroutine(PortalIn());
            

            if (count >= max && isDeactiveBox == false)
            {
                boxCollider.enabled = false;
            }
        }
    }

    private IEnumerator PortalIn()
    {
        if (count >= telePosList.Count && isDeactiveBox == false)
        {
            Debug.LogWarning("No more teleport positions available.");
            yield break;
        }

        rb.simulated = false;
        player.playerMovement.anim.SetTrigger(CacheString.TAG_PORTALIN);
        yield return StartCoroutine(MoveInPortal());
        yield return new WaitForSeconds(0.5f);

        player.transform.position = telePosList[count].position;
        if (isDeactiveBox == false)
        {
            count++;
        }

        player.playerMovement.anim.SetTrigger(CacheString.TAG_PORTALOUT);
        yield return new WaitForSeconds(0.5f);
        rb.simulated = true;
    }

    private IEnumerator MoveInPortal()
    {
        float timer = 0;
        Vector2 targetPos = telePosList[count].position;

        while (timer < 0.5f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, targetPos, 3 * Time.deltaTime);
            yield return null;
            timer += Time.deltaTime;

            if (Vector2.Distance(player.transform.position, targetPos) < 0.1f)
                break;
        }
    }

/*    private void OnDrawGizmosSelected()
    {
        telePosList.Clear();
        for (int i = 0; i < child.childCount; i++)
        {
            telePosList.Add(child.GetChild(i));
        }

        max = telePosList.Count;
        Debug.Log(max);
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 7.5f;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private PlayerCtrl p;

    private void Update()
    {
        if (playerRb != null)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                direction = Vector3.right;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                direction = Vector3.left;
            }

            playerRb.velocity = new Vector2(speed * direction.x, playerRb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
                p.playerMovement.ChangeAnim(CacheString.TAG_ISRUNNING, true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl playerCtrl = Cache.GetCharacter(other);
        if (playerCtrl != null)
        {
            p = playerCtrl;
            playerRb = playerCtrl.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerCtrl playerCtrl = Cache.GetCharacter(other);
        if (playerCtrl != null && playerRb != null)
        {
            playerRb.velocity = Vector2.zero;
            playerRb = null;
        }
    }
}

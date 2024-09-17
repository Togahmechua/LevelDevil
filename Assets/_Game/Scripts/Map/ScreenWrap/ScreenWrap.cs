using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrap : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // Get world coordinates for the screen edges
        Vector3 rightSide = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector3 leftSide = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f));

        float rightEdge = rightSide.x;
        float leftEdge = leftSide.x;
        float topEdge = rightSide.y;
        float bottomEdge = leftSide.y;

        // Horizontal wrapping
        if (screenPos.x <= 0 && rb.velocity.x < 0)
        {
            transform.position = new Vector2(rightEdge, transform.position.y);
        }
        else if (screenPos.x >= Screen.width && rb.velocity.x > 0)
        {
            transform.position = new Vector2(leftEdge, transform.position.y);
        }

        // Vertical wrapping
        if (screenPos.y <= 0 && rb.velocity.y < 0)
        {
            transform.position = new Vector2(transform.position.x, topEdge);

            // Reset velocity to avoid accumulating speed from gravity
            rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset the Y velocity after teleporting
        }
        else if (screenPos.y >= Screen.height && rb.velocity.y > 0)
        {
            transform.position = new Vector2(transform.position.x, bottomEdge);

            // Reset velocity to avoid accumulating speed from gravity
            rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset the Y velocity after teleporting
        }
    }
}

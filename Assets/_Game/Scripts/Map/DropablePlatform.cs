using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropablePlatform : DestroyOBJ
{
    [SerializeField] private float speed;
    [SerializeField] private int direction;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private bool isTouching;

    private void Update()
    {
        if (isTouching == true)
        {
            Move(direction);
        }
        DestroyByDistance(transform);
    }


    private void Move(int direction)
    {
        Vector3 moveVector = Vector3.zero;

        switch (direction)
        {
            case (int)DirectionEnum.Up:
                moveVector = Vector3.up;
                break;
            case (int)DirectionEnum.Down:
                moveVector = Vector3.down;
                break;
            case (int)DirectionEnum.Left:
                moveVector = Vector3.left;
                break;
            case (int)DirectionEnum.Right:
                moveVector = Vector3.right;
                break;
            default:
                Debug.LogWarning("Direction not recognized");
                break;
        }

        transform.parent.Translate(moveVector * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = Cache.GetCharacter(other);
        if(player != null)
        {
            box.enabled = false; 
            isTouching = true;
        }
    }
}

public enum DirectionEnum
{
    Up = 0,
    Down = 1,    
    Left = 2,
    Right = 3
}

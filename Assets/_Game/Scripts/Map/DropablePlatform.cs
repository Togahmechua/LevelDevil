using DG.Tweening;
using System.Collections;
using UnityEngine;

public class DropablePlatform : DestroyOBJ
{
    [SerializeField] private Transform movingObj;
    [SerializeField] private float speed;
    [SerializeField] private float duration;
    [SerializeField] private DirectionEnum direction;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private bool isTouching;


    private void Start()
    {
        if (movingObj == null)
        {
            movingObj = transform.parent;
        }
    }

    private void Update()
    {
        if (isTouching)
        {
            isTouching = false;
        }
        /*DestroyByDistance(transform);*/
    }

    private void MoveCoroutine(DirectionEnum direction)
    {
        Vector3 moveVector = Vector3.zero;

        switch (direction)
        {
            case DirectionEnum.Up:
                moveVector = Vector3.up;
                break;
            case DirectionEnum.Down:
                moveVector = Vector3.down;
                break;
            case DirectionEnum.Left:
                moveVector = Vector3.left;
                break;
            case DirectionEnum.Right:
                moveVector = Vector3.right;
                break;
            default:
                Debug.LogWarning("Direction not recognized");
                break;
        }

        movingObj.DOBlendableMoveBy(moveVector * speed, duration);
    }

    private void Move(DirectionEnum direction)
    {
        if (movingObj == null)
        {
            
            Debug.LogWarning("Parent Transform is null");
            return;
        }

        MoveCoroutine(direction);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = Cache.GetCharacter(other);
        if (player != null)
        {
            box.enabled = false;
            isTouching = true;
            Move(direction);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemyRb;
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    public float leftEnd;
    public float rightEnd;
    public bool movingLeft;

    void Awake()
    {
        leftEnd = transform.position.x - movementDistance;
        rightEnd = transform.position.x + movementDistance;
    }

    void FixedUpdate()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEnd)
            {
                enemyRb.MovePosition(enemyRb.position + speed * Time.deltaTime * Vector2.left);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEnd)
            {
                enemyRb.MovePosition(enemyRb.position + speed * Time.deltaTime * Vector2.right);
            }
            else
            {
                movingLeft = true;
            }
        }
    }
}

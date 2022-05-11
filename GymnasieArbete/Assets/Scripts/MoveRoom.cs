using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoom : MonoBehaviour
{
    public Vector2 camChangeMin;
    public Vector2 camChangeMax;
    public Vector3 playerChange;
    [SerializeField] private CameraMovement cam;

    //N�r man kolliderar med gameobject f�rflyttas spelaren och kamerans gr�nser i x-och y-axeln. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //�ndra gr�nserna f�r de l�gsta v�rdena i x-och y-axeln.
            cam.minPosition.x += camChangeMin.x;
            cam.minPosition.y += camChangeMin.y;

            //�ndra gr�nserna f�r de h�gsta v�rdena i x-och y-axeln.
            cam.maxPosition.x += camChangeMax.x;
            cam.maxPosition.y += camChangeMax.y;

            //�ndra positionen f�r spelaren.
            collision.transform.position += playerChange;
        }
    }
}

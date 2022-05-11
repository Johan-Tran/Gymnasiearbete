using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoom : MonoBehaviour
{
    public Vector2 camChangeMin;
    public Vector2 camChangeMax;
    public Vector3 playerChange;
    [SerializeField] private CameraMovement cam;

    //När man kolliderar med gameobject förflyttas spelaren och kamerans gränser i x-och y-axeln. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Ändra gränserna för de lägsta värdena i x-och y-axeln.
            cam.minPosition.x += camChangeMin.x;
            cam.minPosition.y += camChangeMin.y;

            //Ändra gränserna för de högsta värdena i x-och y-axeln.
            cam.maxPosition.x += camChangeMax.x;
            cam.maxPosition.y += camChangeMax.y;

            //Ändra positionen för spelaren.
            collision.transform.position += playerChange;
        }
    }
}

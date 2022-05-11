using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float smoothing;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    private  Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        //Gör att kameran följer efter spelaren. Om inte kameran i samma position som spelaren följer den efter. 
        if (transform.position != player.position)
        {
            //Spelarens position
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

            //Ser till att kameran inte går över de angivna värdena minposition och maxposition. 
            targetPosition.x = Mathf.Clamp(player.position.x, minPosition.x, maxPosition.x);

            targetPosition.y = Mathf.Clamp(player.position.y, minPosition.y, maxPosition.y);

            //Gör att kamerans rörelse blir mjuk när den går mot spelaren.
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float moveSpeed = 5.0f;
    public Vector2 moveDirection;
    public Animator animator;

    void Update()
    {
        //Inmatning
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        //Ändrar värdet av animationen för när man går.
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        //Hastighet för när animationerna ändras.
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        LastDirection();
    }

    void FixedUpdate()
    {
        //Gör så att spelaren kan gå.
        playerRb.MovePosition(playerRb.position + moveSpeed * moveDirection.normalized * Time.fixedDeltaTime);
    }

    //Animationen för när man pratar med en NPC. 
    public void LastDirection()
    {
        //Uppdaterar värdet av idle-animation när man går.
        if ((moveDirection.x != 0 || moveDirection.y != 0))
        {
            animator.SetFloat("LastHorizontal", moveDirection.x);
            animator.SetFloat("LastVertical", moveDirection.y);
        }
    }
}

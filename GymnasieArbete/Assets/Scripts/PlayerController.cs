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

        //�ndrar v�rdet av animationen f�r n�r man g�r.
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        //Hastighet f�r n�r animationerna �ndras.
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        LastDirection();
    }

    void FixedUpdate()
    {
        //G�r s� att spelaren kan g�.
        playerRb.MovePosition(playerRb.position + moveSpeed * moveDirection.normalized * Time.fixedDeltaTime);
    }

    //Animationen f�r n�r man pratar med en NPC. 
    public void LastDirection()
    {
        //Uppdaterar v�rdet av idle-animation n�r man g�r.
        if ((moveDirection.x != 0 || moveDirection.y != 0))
        {
            animator.SetFloat("LastHorizontal", moveDirection.x);
            animator.SetFloat("LastVertical", moveDirection.y);
        }
    }
}

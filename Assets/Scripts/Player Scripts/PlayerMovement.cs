using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public VectorValue startingPosition;
    public Vector2 lastMotionVector;
    

    void Start(){
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        transform.position = startingPosition.initialValue;
    }

    void Update() 
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimatorAndMove();

        if (change.x != 0 || change.y != 0)
        {
            lastMotionVector = new Vector2(change.x, change.y).normalized;
        }

        animator.SetFloat("lastX", change.x);
        animator.SetFloat("lastY", change.y);


    }

    void UpdateAnimatorAndMove()
    {  
        if (change != Vector3.zero) {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        } else{
            animator.SetBool("moving", false);
        }

    }
    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.fixedDeltaTime);
    }
}

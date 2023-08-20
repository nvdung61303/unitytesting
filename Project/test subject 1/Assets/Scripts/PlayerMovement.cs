using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    // private Animator anim;

    //ground checker
    private bool isOnTheGround = true;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask jumpable;
    

    //movement variables
    private float xDir = 0f;
    [SerializeField] private float ms = 5f; //movespeed
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravityModifier = 1f;


    private enum MovementState { idle, running, jumping, falling } //character moving state
    // Start is called before the first frame update
    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       coll = GetComponent<BoxCollider2D>();
       sprite = GetComponent<SpriteRenderer>();
      //  anim = GetComponent<Animator>();
       Physics2D.gravity *= gravityModifier;
    }

    // Update is called once per frame
    private void Update()
    {

      //movement

      //moving A-D
      float xDir = Input.GetAxis("Horizontal");
      rb.velocity = new Vector2(xDir * ms, rb.velocity.y);
      
      //spacebar jump
      isOnTheGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, jumpable);
      if (Input.GetButtonDown("Jump") && isOnTheGround) 
      {
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        isOnTheGround = false;
      }

      if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
      {
      rb.AddForce(new Vector2(rb.velocity.x, rb.velocity.y * 0.4f));
      }

      // UpdateCharacterAnimationState(); 
    }
        
        
    // private void UpdateCharacterAnimationState()
    // {
    //     MovementState state;

    //     //detect character action
    //     if (xDir > 0f)
    //     {
    //       state = MovementState.running;
    //       sprite.flipX = false;
    //     }
    //     else if (xDir < 0f)
    //     {
    //       state = MovementState.running;
    //       sprite.flipX = true;
    //     }
    //     else
    //     {
    //       state = MovementState.idle;
    //     }

    //     if (rb.velocity.y > .1f)
    //     {
    //       state = MovementState.jumping;
    //     }
    //     else if (rb.velocity.y < -.1f)
    //     {
    //       state = MovementState.falling;
    //     }

    //     //cast corresponding animation
    //     anim.SetInteger("state", (int)state);
    // }

}

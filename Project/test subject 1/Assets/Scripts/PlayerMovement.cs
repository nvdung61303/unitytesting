using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    

    

    //movement variables
    private float xDir = 0f;
    [SerializeField] private float ms = 5f; //movespeed
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask jumpable;
    public float gravityModifier = 2;

    private enum MovementState { idle, running, jumping, falling } //character moving state
    // Start is called before the first frame update
    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       coll = GetComponent<BoxCollider2D>();
       sprite = GetComponent<SpriteRenderer>();
       anim = GetComponent<Animator>();
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
      if (Input.GetButtonDown("Jump") && IsOnTheGround()) 
      {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
      } 
    }
        
        
    private void UpdateCharacterAnimationState()
    {
        MovementState state;

        //detect character action
        if (xDir > 0f)
        {
          state = MovementState.running;
          sprite.flipX = false;
        }
        else if (xDir < 0f)
        {
          state = MovementState.running;
          sprite.flipX = true;
        }
        else
        {
          state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
          state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
          state = MovementState.falling;
        }

        //cast corresponding animation
        anim.SetInteger("state", (int)state);
    }

    private bool IsOnTheGround() 
    {
      return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpable);
    }

}

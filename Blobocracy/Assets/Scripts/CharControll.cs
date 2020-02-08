using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControll : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 9;
    protected Rigidbody2D body;
    protected SpriteRenderer sprite;
    protected Vector2 velocity;

    bool isGrounded;

    Animator animator;

    
    [SerializeField, Tooltip("Acceleration while grounded.")]
    float acceleration = 75;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float deceleration = 70;

    [SerializeField, Tooltip("How high yah boy is jumping.")]
    float jumpHeight = 3;

    int previous_face;
    bool faceLeft;
    bool faceRight;

    const float jumpStagger = .6f;

    float jumpTime = jumpStagger;
    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>(); 
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        if (moveInput > 0) {
            sprite.flipX = true;
        } else if (moveInput < 0) {
            sprite.flipX = false;
        }
        
        //Lets do some jumping 
        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }   

        transform.Translate(velocity * Time.deltaTime);
        //We need a slight delay to line up with the animatino
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetBool("Jump", true);
            isJumping = true;
            isGrounded = false;
        }

        //Check if the startup animation is completed, then apply force
        if (isJumping) {
            if (jumpTime > 0) {
                jumpTime -= Time.deltaTime;
            } else {
                isJumping = false;
                body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                jumpTime = jumpStagger;
            }
        }
    }  
    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Floor" && !isJumping)
        {
            animator.SetBool("Jump", false);
            isGrounded = true;
        }
    }

}

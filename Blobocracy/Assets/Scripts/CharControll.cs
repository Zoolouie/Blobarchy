using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharControll : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 9;
    protected Rigidbody2D body;
    protected SpriteRenderer sprite;
    protected Vector2 velocity;

    bool isGrounded;

    Animator animator;

    public Image image;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float acceleration;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float deceleration;

    [SerializeField, Tooltip("How high yah boy is jumping.")]
    float jumpHeight;


    const float default_jump_height = 5;
    const float frog_jump_height = 10;
    const float default_blob_scale = 1.152608F;
    const float blob_scale = 3;

    int previous_face;
    bool faceLeft;
    bool faceRight;

    const float jumpStagger = .6f;

    float jumpTime = jumpStagger;
    bool isJumping = false;
    //TEST
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();

        // INSTANTIATE CHARACTER VARIABLES
        acceleration = 75;
        deceleration = 70;
        jumpHeight = 5;

        inventory = gameObject.GetComponent<Inventory>();
    }


    void SetDefault() {
        jumpHeight = default_jump_height;
        gameObject.transform.localScale = new Vector3(default_blob_scale, default_blob_scale, default_blob_scale);
    }
    void CheckInventory() {
        SetDefault();
        int[] array = inventory.GetInventory();
        int i = array.Length - 1;
        //Debug.Log(array[0]);
        while (i >= 0) {
            switch (array[i]) {
                case 1:
                    //Dosomething
                    // Debug.Log("Has Coin");
                    gameObject.transform.localScale = new Vector3(blob_scale, blob_scale, blob_scale);
                    break;
                case 2:
                    //Frog
                    // Debug.Log("Has Frog");
                    jumpHeight = frog_jump_height;
                    image.GetComponent<CurrentAbsorbed>().SetCurrentPowerUp(Consumables.Frog);
                    break;
                case 3:
                    //Trash - do nothing
                    // Debug.Log("Has Trash");
                    break;
                default:
                    break;
            }
            i = i - 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        CheckInventory();
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
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Floor" && !isJumping)
        {
            animator.SetBool("Jump", false);
            isGrounded = true;
        }
    }



}

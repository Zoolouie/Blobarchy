using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
DESCRIPTION:
  Controls characters movement and behavior
USAGE:
  Attach to character
*/
public class CharControll : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
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

    [SerializeField, Tooltip("How fast yah boy is moving.")]
    float speed;


    const float default_jump_height = 5;
    const float frog_jump_height = 10;
    const float turtle_jump_height = 3;
    const float default_speed = 9;
    const float turtle_speed = 3;
    const float default_blob_scale = 1.152608F;
    const float blob_scale = 3;
    const float thrust_coefficient = 10;

    const float threshold = -20;

    int previous_face;
    bool faceLeft;
    bool faceRight;

    const float jumpStagger = .6F;

    float jumpTime = jumpStagger;
    bool isJumping = false;
    bool isFalling = false;
    bool hasBird = false;
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
        jumpHeight = default_jump_height;
        speed = default_speed;

        inventory = gameObject.GetComponent<Inventory>();
    }


    void SetDefault() {
        jumpHeight = default_jump_height;
        gameObject.transform.localScale = new Vector3(default_blob_scale, default_blob_scale, default_blob_scale);
        speed = default_speed;
        hasBird = false;
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
                    image.GetComponent<CurrentAbsorbed>().SetCurrentPowerUp(Consumables.Coin);
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
                    image.GetComponent<CurrentAbsorbed>().SetCurrentPowerUp(Consumables.Trash);
                    break;
                case 4:
                    //Turtle - go slower and make tougher?
                    image.GetComponent<CurrentAbsorbed>().SetCurrentPowerUp(Consumables.Turtle);
                    speed = turtle_speed;
                    jumpHeight = turtle_jump_height;
                    break;
                case 5:
                    image.GetComponent<CurrentAbsorbed>().SetCurrentPowerUp(Consumables.Bird);
                    hasBird = true;
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

        if (transform.position.y < threshold) {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
            return;
        }

        if (body.velocity.y < 0) {
            isFalling = true;
        } else {
            isFalling = false;
        }

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

        if (Input.GetButton("Jump") && isFalling && hasBird){
            //if have bird, are falling, and holding jump, add upward force to glide:
            body.AddForce(transform.up * thrust_coefficient);
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

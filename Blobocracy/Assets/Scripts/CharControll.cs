using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControll : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 9;
    protected Rigidbody2D body;
    protected Vector2 velocity;

    
    [SerializeField, Tooltip("Acceleration while grounded.")]
    float acceleration = 75;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float deceleration = 70;

    [SerializeField, Tooltip("How high yah boy is jumping.")]
    float jumpHeight = 3;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        //Lets do some jumping 
        velocity.y = 0;

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }   

        transform.Translate(velocity * Time.deltaTime);
                if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("tset");
            body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    void FixedUpdated() {
        

    }
}

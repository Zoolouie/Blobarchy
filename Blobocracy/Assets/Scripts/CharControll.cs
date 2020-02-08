using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControll : MonoBehaviour
{
    protected Rigidbody2D body;
    protected Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0.0f, 0.0f);
        // float vertical = Input.GetAxis("Vertical") * speed;
        transform.Translate(movement * Time.deltaTime);
    }
}

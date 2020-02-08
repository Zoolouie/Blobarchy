using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehavior : MonoBehaviour
{
    // Rigidbody2D rb2d;
    // Start is called before the first frame update
   
    /*
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
	Debug.Log("Collision initiated: " + gameObject.name + " and " + collisionInfo.collider.name);
	print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
    	print("Their relative velocity is " + collisionInfo.relativeVelocity);
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
	print(gameObject.name + " and " + collisionInfo.collider.name + " are still colliding");
    }
   */ 
   

    /*void OnTriggerEnter2D(Collider2D other)
    {
    	Debug.Log("Collision detected with trigger object " + other.name);
    }
    */
    Inventory inventory;
    
    void Start()
    {
	inventory = gameObject.GetComponent<Inventory>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Collision still happening");
	inventory.SetInventory(1); //test object
	
    }
    
    /*
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Collision exited");
    }
    */
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehavior : MonoBehaviour
<<<<<<< HEAD
{   
    private Vector3 scaleChange;// = new Vector3(2.0f, 2.0f, 0.0f);
    void OnTriggerEnter2D(Collider2D other)
=======
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
>>>>>>> 0b6de10485a33cccc0a9a407972ef8d8dc1cd3e7
    {
    	if (other.gameObject.CompareTag("Collectables"))
                {
                    scaleChange = new Vector3(
                    other.gameObject.transform.localScale.x, 
                    other.gameObject.transform.localScale.y, 
                    0);

                    other.gameObject.SetActive(false);
                    
                    gameObject.transform.localScale += scaleChange;
                }
    }
    */
    Inventory inventory;
    
    void Start()
    {
	inventory = gameObject.GetComponent<Inventory>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
<<<<<<< HEAD
        
=======
        //Debug.Log("Collision still happening");
	inventory.SetInventory(1); //test object
	
>>>>>>> 0b6de10485a33cccc0a9a407972ef8d8dc1cd3e7
    }
    
    /*
    void OnTriggerExit2D(Collider2D other)
    {
        
    }
    */
   
}

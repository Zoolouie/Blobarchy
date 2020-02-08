using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehavior : MonoBehaviour
{   
	/*    
	private Vector3 scaleChange;// = new Vector3(2.0f, 2.0f, 0.0f);
    void OnTriggerEnter2D(Collider2D other)
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
        //Debug.Log("Collision still happening");
	
		// Get item name from object tag:
		string itemName = other.tag;
		// Add corresponding item to inventory:
		int item = 0;
	
		switch(itemName)
		{
		    case "Coin":
				item = 1;
				break;
			case "Frog":
				item = 2;
				break;
			case "Trash":
				item = 3;
				break;
			case "Turtle":
				item = 4;
				break;
			case "Glider":
				item = 5;
				break;
			default:
				Debug.Log("Unknown item");
				break;		
		}
		
		//Add to inventory:		
		inventory.SetInventory(item);
		
		//Destroy item:
		Destroy(other.gameObject);
	
    }
   
}

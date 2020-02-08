using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehavior : MonoBehaviour
{

	// private Vector3 scaleChange;// = new Vector3(2.0f, 2.0f, 0.0f);
    // Rigidbody2D rb2d;
    // Start is called before the first frame update


    Inventory inventory;
	ItemRender stomach;

    void Start()
    {
		inventory = gameObject.GetComponent<Inventory>();
		stomach = gameObject.GetComponent<ItemRender>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Collision still happening");

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
			case "Bird":
				item = 5;
				break;
			default:
				Debug.Log("Unknown item");
				break;
		}



		//Add to inventory:
		inventory.SetInventory(item);

		//render it in its stomach
		//Debug.Log("It is rendering stom");
		stomach.renderStomach();

		//Destroy item:
		Destroy(other.gameObject);

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int inventorySize;
    public int[] inventory; //use queue later? set?
    private int idx; //index to add new item to
    // Start is called before the first frame update
    void Start()
    {
        inventorySize = 1; //INVENTORY SIZE!!
	inventory = new int[inventorySize];
	idx = 0;
    }
    
    void Update(){
	//Debug.Log("Inventory: " + inventory[0]);
    }

    public void SetInventory(int item){
	// Set list at idx to item:	
	inventory[idx] = item;
	Debug.Log("Added item " + item);
	
	// Update idx:
	// if idx at end, set idx to 0:
	if (idx >= inventory.Length - 1){
	    idx = 0;
	}
	else{
	    idx ++;
	}
    }
    
    public int[] GetInventory(){
	return inventory;
    }
}

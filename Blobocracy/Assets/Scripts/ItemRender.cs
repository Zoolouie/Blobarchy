using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRender : MonoBehaviour
{
    Inventory inventory;
    GameObject stomachContents;
    bool hasEaten =false;
    // Start is called before the first frame update
    void Start()
    {
        inventory = gameObject.GetComponent<Inventory>();
    }


    // Update is called once per frame
    void Update()
    {
        if(hasEaten) {
            stomachContents.transform.position = transform.position + new Vector3(0,0,-1);

        }
    }

    public void renderStomach() {
        
        int stomach = inventory.GetInventory()[0];
        Debug.Log(stomach);
        switch (stomach)
        {
            case 0: break;
            case 1:
                if (!hasEaten) {
                    Debug.Log("its here ");
                stomachContents = (GameObject) Instantiate( GameObject.Find("Dud-Coin") ,
                             transform.position + new Vector3(0,0,-1),
                             Quaternion.identity);

                }

                break;
            case 2: break;
        }
        hasEaten = true;
    }
    
}

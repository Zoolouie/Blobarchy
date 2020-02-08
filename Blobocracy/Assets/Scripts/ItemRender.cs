using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
  DESCRIPTION:
    Renders items in stomach
  USAGE:
    Attach to character
*/

public class ItemRender : MonoBehaviour
{
    Inventory inventory;
    GameObject stomachContents;
    bool hasEaten =false;

    Image stomachImage;

    public Sprite FROG, TURTLE, BIRD, COIN, TRASH;

    // Start is called before the first frame update
    void Start()
    {
        inventory = gameObject.GetComponent<Inventory>();
        stomachContents = (GameObject) Instantiate( GameObject.FindWithTag("Dud") ,
                             transform.position + new Vector3(0,0,-1),
                             Quaternion.identity);
        stomachImage = stomachContents.GetComponent<Image>();

    }


    // Update is called once per frame
    void Update()
    {

        if(hasEaten) {
            float locationY = (float)(transform.localScale.x)*-0.2F;
            float locationX = (float)(transform.localScale.y)*-0.2F;


            stomachContents.transform.position = transform.position + new Vector3(locationX,
                                                                                    locationY,
                                                                                    -1);
            
            stomachContents.transform.Rotate(0.5F, 0.5F, 0.1F );
        }
    }

    public void renderStomach() {
        hasEaten = true;
        int stomachItem = inventory.GetInventory()[0];
        switch(stomachItem) {
            case 0:
                stomachImage.enabled = false;
                stomachImage.sprite = null;
                break;
            case 1:
                stomachImage.sprite = COIN;
                break;
            case 2:
                stomachImage.sprite = FROG;
                break;
            case 3:
                stomachImage.sprite = TRASH;
                break;
            case 4:
                stomachImage.sprite = TURTLE;
                break;
            default:
                stomachImage.enabled = false;
                stomachImage.sprite = null;
                break;
        }
        
    }

}

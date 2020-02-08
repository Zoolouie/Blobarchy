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

[RequireComponent(typeof(Image))]
public class ItemRender : MonoBehaviour
{
    Inventory inventory;
    GameObject stomachContents;
    bool hasEaten =false;

    public SpriteRenderer spriteR;

    //Image stomachImage;

    public Sprite FROG, TURTLE, BIRD, COIN, TRASH;

    // Start is called before the first frame update
    void Start()
    {
        inventory = gameObject.GetComponent<Inventory>();
        stomachContents = (GameObject) Instantiate( GameObject.FindWithTag("Dud") ,
                             transform.position + new Vector3(-100,-100,-1),
                             Quaternion.identity);
        spriteR = stomachContents.GetComponent<SpriteRenderer>();
        //stomachImage = stomachContents.GetComponent<Image>();

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
            
            stomachContents.transform.Rotate(0.35F, 0.5F, 0.3F );
        }
    }

    public void renderStomach() {
        hasEaten = true;
        int stomachItem = inventory.GetInventory()[0];
        
        // if(stomachContents == null) {
        //     Debug.Log("Bigger Problem");
        // }
        switch(stomachItem) {
            case 0:
                //stomachContents.enabled = ;
                spriteR.sprite  = null;
                break;
            case 1:
                spriteR.sprite  = COIN;
                
                break;
            case 2:
                spriteR.sprite  = FROG;
                
                break;
            case 3:
                spriteR.sprite  = TRASH;
                break;
            case 4:
                spriteR.sprite  = TURTLE;
                break;
            case 5:
                spriteR.sprite = BIRD;
                break;
            default:
                //stomachContents.enabled = false;
                spriteR.sprite = null;
                break;
        }
        
    }

}

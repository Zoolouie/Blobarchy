using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
  DESCRIPTION:
    Displays currently consumed items in UI
  USAGE:
    ?????
*/

    public enum Consumables {
        None,
        Coin,
        Frog,
        Trash,
        Turtle,
        Bird
    }

[RequireComponent(typeof(Image))]
public class CurrentAbsorbed : MonoBehaviour
{

    // Start is called before the first frame update
    Image currentImage;
    public Sprite COIN, FROG, TRASH, TURTLE, BIRD;
    void Start()
    {
        currentImage = gameObject.GetComponent<Image>();
        SetCurrentPowerUp(Consumables.None);
    }

    //Set the powerup display by itemType
    public void SetCurrentPowerUp(Consumables itemType) {
        currentImage.enabled = true;
        switch(itemType) {
            case Consumables.Coin:
                currentImage.sprite = COIN;
                break;
            case Consumables.Frog:
                currentImage.sprite = FROG;
                break;
            case Consumables.Trash:
                currentImage.sprite = TRASH;
                break;
            case Consumables.Turtle:
                currentImage.sprite = TURTLE;
                break;
            case Consumables.Bird:
                currentImage.sprite = BIRD;
                break;
            default:
                currentImage.enabled = false;
                currentImage.sprite = null;
                break;
        }
    }
}

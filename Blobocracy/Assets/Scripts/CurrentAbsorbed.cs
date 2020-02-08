using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CurrentAbsorbed : MonoBehaviour
{
    enum Consumables {
        None,
        Frog,
        Turtle,
        Bird
    }
    // Start is called before the first frame update
    Image currentImage;
    public Sprite FROG, TURTLE, BIRD;
    void Start()
    {
        currentImage = gameObject.GetComponent<Image>();
        SetCurrentPowerUp(Consumables.None);
    }

    //Set the powerup display by itemType
    void SetCurrentPowerUp(Consumables itemType) {
        currentImage.enabled = true;
        switch(itemType) {
            case Consumables.Frog:
                currentImage.sprite = FROG;
                break;
            case Consumables.Bird:
                currentImage.sprite = BIRD;
                break;
            case Consumables.Turtle:
                currentImage.sprite = TURTLE;
                break;
            default:
                currentImage.enabled = false;
                currentImage.sprite = null;
                break;
        }
    }
}

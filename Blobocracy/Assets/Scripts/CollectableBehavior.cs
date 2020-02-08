using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehavior : MonoBehaviour
{   
    private Vector3 scaleChange;// = new Vector3(2.0f, 2.0f, 0.0f);
    void OnTriggerEnter2D(Collider2D other)
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

    void OnTriggerStay2D(Collider2D other)
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }
	
   
}

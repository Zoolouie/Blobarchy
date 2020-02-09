using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    void OnTriggerEnter2D() {
        if (SceneManager.GetActiveScene().name == "Intro"){
            SceneManager.LoadScene("Level1");
        }
        else{
          SceneManager.LoadScene("Intro");
        }
    }
}

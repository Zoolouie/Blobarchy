using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBox : MonoBehaviour
{
    void onTriggerEnter2D() {
        SceneManager.LoadScene("Level 1");
    }
}

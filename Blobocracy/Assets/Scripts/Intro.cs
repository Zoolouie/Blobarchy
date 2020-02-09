using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    public Sprite logo;
    float timer;
    float timer2;
    Image image;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.canvasRenderer.SetAlpha(0.0f);
        fadeIn();
        timer = 3f;
        timer2 = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;

        if(timer2 <= 0) {
            SwitchScenes();
        }

        if(timer <= 0) {
            SwitchImages();
            fadeOut();
        }
    }

    void SwitchImages() {
        image.sprite = logo;
    }

    void fadeOut() {
        image.CrossFadeAlpha(0, 2, false);
    }
    void fadeIn() {
        image.CrossFadeAlpha(1, 2, false);
    }

    void SwitchScenes() {
        SceneManager.LoadScene("Intro");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class ThanksForPlayingEnd : MonoBehaviour
{
    public Image fadeIntoBlack;
    public float fadeSpeed = 1f; // Fade speed
    
    private void Start()
    { 
        fadeIntoBlack = GetComponent<Image>();
        // Start with full transparency
        fadeIntoBlack.color = new Color(0f, 0f, 0f, 0f);
    }

    private void Update()
    {
        // Incrementally increase alpha over time
        fadeIntoBlack.color = new Color(0f, 0f, 0f, Mathf.Lerp(fadeIntoBlack.color.a, 1f, Time.deltaTime / fadeSpeed));

        if (this.gameObject.activeSelf)
        {
            Invoke("ReloadMenu", 3);
        }
    }

    public void ReloadMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}

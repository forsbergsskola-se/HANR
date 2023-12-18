using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PauseManagerScript : MonoBehaviour

{
    private bool isPaused = false;
    public static PauseManagerScript instance;
    public GameObject GamePausePanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (GamePausePanel != null)
        {
            GamePausePanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;

            if (GamePausePanel != null)
            {
                GamePausePanel.SetActive(true);
            }
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
            
            if (GamePausePanel != null)
            {
                GamePausePanel.SetActive(false);
            }
        }
    }
}
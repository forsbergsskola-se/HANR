using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManagerScript : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

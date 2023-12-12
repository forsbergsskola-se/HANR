using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void gameOver()
    {
        gameOverUi.SetActive(true);
    }
}

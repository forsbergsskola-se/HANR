using System;
using System.Collections;
using CustomObjects;
using Enemy.BossEnemy;
using UnityEngine;

public class ColourTriggerChange : MonoBehaviour
{
    private Light mainLight;
    private Coroutine colorTransitionCoroutine;
    
    [SerializeField] public BoolVariable playBossMusic;
    
    [SerializeField] private float transitionDuration = 2.0f;
    [SerializeField] private Color bossColor;
    [SerializeField] private Color normalColor;

    public BossEnemyTakeDamage bossDeath;
    //private bool isTransitioning;
    private bool bosskilled;
    

    void Start()
    {
        mainLight = GameObject.FindWithTag("MainLight")?.GetComponent<Light>();
        
        bossDeath.bossKilled.AddListener(Stop);

        if (mainLight == null)
        {
            Debug.LogError("Main light not found. Make sure it has the 'MainLight' tag and a Light component.");
        }
    }


    private void OnDestroy()
    {
        bossDeath.bossKilled.RemoveListener(Stop);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!bosskilled)
        {
            // Start the boss color transition coroutine and store a reference to it
            colorTransitionCoroutine = StartCoroutine(LerpColorboss(bossColor));
            playBossMusic.setValue(true);
        }
    }

    private void Stop()
    {
        if (colorTransitionCoroutine != null)
        {
            StopCoroutine(colorTransitionCoroutine);
        }

        bosskilled = true;
        // Start the normal color transition coroutine
        StartCoroutine(LerpColor(normalColor));
    }
    

    IEnumerator LerpColorboss(Color targetColor)
    {
        //isTransitioning = true;

        Color initialColor = mainLight.color;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            mainLight.color = Color.Lerp(initialColor, targetColor, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainLight.color = targetColor;
        //isTransitioning = false;
    }
    IEnumerator LerpColor(Color targetColor)
    {

        Color initialColor = mainLight.color;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            mainLight.color = Color.Lerp(initialColor, targetColor, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainLight.color = targetColor;
      
    }
    
}
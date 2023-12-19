using System.Collections;
using CustomObjects;
using UnityEngine;

public class ColourTriggerChange : MonoBehaviour
{
    private Light mainLight;
    private Coroutine colorTransitionCoroutine;
    
    [SerializeField] public BoolVariable playBossMusic;
    
    [SerializeField] private float transitionDuration = 2.0f;
    [SerializeField] private Color bossColor;
    [SerializeField] private Color normalColor;

    private bool isTransitioning = false;
    

    void Start()
    {
        mainLight = GameObject.FindWithTag("MainLight")?.GetComponent<Light>();

        if (mainLight == null)
        {
            Debug.LogError("Main light not found. Make sure it has the 'MainLight' tag and a Light component.");
        }
    }

  
    private void OnTriggerEnter(Collider other)
    {
        // Start the boss color transition coroutine and store a reference to it
        colorTransitionCoroutine = StartCoroutine(LerpColorboss(bossColor));
        playBossMusic.setValue(true);
    }

    private void OnTriggerExit(Collider other)
    {
        // Stop the boss color transition coroutine if it's running
        if (colorTransitionCoroutine != null)
        {
            StopCoroutine(colorTransitionCoroutine);
        }

        // Start the normal color transition coroutine
        StartCoroutine(LerpColor(normalColor));
    }


    IEnumerator LerpColorboss(Color targetColor)
    {
        isTransitioning = true;

        Color initialColor = mainLight.color;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            mainLight.color = Color.Lerp(initialColor, targetColor, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainLight.color = targetColor;
        isTransitioning = false;
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
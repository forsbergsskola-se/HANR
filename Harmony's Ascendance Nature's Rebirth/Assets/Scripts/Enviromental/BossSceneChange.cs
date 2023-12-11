using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BossSceneChange : MonoBehaviour
{
    private Light mainLight;

    [SerializeField] private Color BossColor;
    [SerializeField] private Color NormalColor;
    // Start is called before the first frame update
    void Start()
    {
        mainLight = GameObject.FindWithTag("MainLight").GetComponent<Light>();
    }



    private void OnTriggerEnter(Collider other)
    {
        BossLightChange();
    }

    private void OnTriggerExit(Collider other)
    {
      NormalLightChange();   
    }

    private void BossLightChange()
    {
        mainLight.color = BossColor;
    }
    
    private void NormalLightChange()
    {
        mainLight.color = NormalColor;
    }
    
    /*IEnumerator LerpColor()
    {
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            // Interpolate between the initial color and the target color
            targetLight.color = Color.Lerp(initialColor, targetColor, elapsedTime / transitionDuration);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the target color is set exactly when the interpolation is complete
        targetLight.color = targetColor;
    } */
}

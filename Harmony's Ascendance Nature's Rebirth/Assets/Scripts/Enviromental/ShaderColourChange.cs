using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]
public class MaterialColorPair
{
    public Material Material;
    public Color OriginalColor;
    public string ColorPropertyName; // Name of the color property in the material
    public Color TargetColor; // Target color for lerping

    public MaterialColorPair(Material material, Color originalColor, string colorPropertyName, Color targetColor)
    {
        Material = material;
        OriginalColor = originalColor;
        ColorPropertyName = colorPropertyName;
        TargetColor = targetColor;
    }
}

public class ShaderColourChange : MonoBehaviour
{
    [SerializeField] private Color targetColor;
    [SerializeField] private float transitionDuration;
    [SerializeField] private Light mainLight;
    [SerializeField] private List<MaterialColorPair> materialsWithOriginalColors = new List<MaterialColorPair>();

    public UnityEvent SaveRiver;

    public Color TargetColor
    {
        get { return targetColor; }
        set { targetColor = value; }
    }

    private void Start()
    {
        SaveRiver.AddListener(RiverSaved);
        StoreOriginalColors();
        RiverSaved();
    }

    private void OnDestroy()
    {
        ResetMaterialColors();
    }

    private void StoreOriginalColors()
    {
        foreach (MaterialColorPair pair in materialsWithOriginalColors)
        {
            pair.OriginalColor = pair.Material.GetColor(pair.ColorPropertyName);
        }
    }

    private void RiverSaved()
    {
        StartCoroutine(LerpLight(targetColor));
        foreach (MaterialColorPair pair in materialsWithOriginalColors)
        {
            Material material = pair.Material;
            Color originalColor = pair.OriginalColor;
            string colorPropertyName = pair.ColorPropertyName;
            Color targetColor = pair.TargetColor;
            LerpMaterialColor(material, targetColor, originalColor, colorPropertyName);
        }
    }

    private void LerpMaterialColor(Material material, Color targetColor, Color originalColor, string colorPropertyName)
    {
        StartCoroutine(LerpColor(material, targetColor, originalColor, colorPropertyName));
    }

    private IEnumerator LerpColor(Material material, Color targetColor, Color originalColor, string colorPropertyName)
    {
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            material.SetColor(colorPropertyName, Color.Lerp(originalColor, targetColor, elapsedTime / transitionDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        material.SetColor(colorPropertyName, targetColor);
    }

    private IEnumerator LerpLight(Color targetColor)
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

    private void ResetMaterialColors()
    {
        foreach (MaterialColorPair pair in materialsWithOriginalColors)
        {
            Material material = pair.Material;
            Color originalColor = pair.OriginalColor;
            string colorPropertyName = pair.ColorPropertyName;
            material.SetColor(colorPropertyName, originalColor);
        }
    }
}

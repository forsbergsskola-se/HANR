using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]
public class MaterialColorPair
{
    public Material Material;
    public List<MaterialColorProperty> ColorProperties = new List<MaterialColorProperty>();

    public MaterialColorPair(Material material, Dictionary<string, Color> targetColors)
    {
        Material = material;

        // Initialize MaterialColorProperty objects with both original and target colors
        foreach (KeyValuePair<string, Color> entry in targetColors)
        {
            Color originalColor = material.GetColor(entry.Key);
            Color targetColor = entry.Value;
            ColorProperties.Add(new MaterialColorProperty(entry.Key, originalColor, targetColor));
        }
    }
}

[System.Serializable]
public class MaterialColorProperty
{
    public string PropertyName;
    public Color OriginalColor;
    public Color TargetColor;

    public MaterialColorProperty(string propertyName, Color originalColor, Color targetColor)
    {
        PropertyName = propertyName;
        OriginalColor = originalColor;
        TargetColor = targetColor;
    }
}

public class ShaderColourChange : MonoBehaviour
{
    [SerializeField] private float transitionDuration;
    [SerializeField] private Light mainLight;
    [SerializeField] private List<MaterialColorPair> materialsWithColorProperties = new List<MaterialColorPair>();

    public UnityEvent SaveRiver;

    private void Start()
    {
        SaveRiver.AddListener(RiverSaved);

    }

    private void OnDestroy()
    {
        ResetMaterialColors();
    }

    private void RiverSaved()
    {
        StartCoroutine(LerpLight());
        foreach (MaterialColorPair pair in materialsWithColorProperties)
        {
            Material material = pair.Material;
            foreach (MaterialColorProperty colorProperty in pair.ColorProperties)
            {
                StartCoroutine(LerpColor(material, colorProperty.TargetColor, colorProperty.PropertyName));
            }
        }
    }

    private void ResetMaterialColors()
    {
        foreach (MaterialColorPair pair in materialsWithColorProperties)
        {
            Material material = pair.Material;
            foreach (MaterialColorProperty colorProperty in pair.ColorProperties)
            {
                material.SetColor(colorProperty.PropertyName, colorProperty.OriginalColor);
            }
        }
    }

    private IEnumerator LerpColor(Material material, Color targetColor, string colorPropertyName)
    {
        Color initialColor = material.GetColor(colorPropertyName);
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            material.SetColor(colorPropertyName, Color.Lerp(initialColor, targetColor, elapsedTime / transitionDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        material.SetColor(colorPropertyName, targetColor);
    }

    private IEnumerator LerpLight()
    {
        Color initialColor = mainLight.color;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            mainLight.color = Color.Lerp(initialColor, Color.white, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainLight.color = Color.white;
    }
}

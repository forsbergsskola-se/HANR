using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public class ColorProperty
{
    public string propertyName;
    public Color color;
}

public class PropertyColourChange : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    [SerializeField] private ColorProperty[] colorProperties;

    public UnityEvent SaveRiver;

    void Start()
    {
        SaveRiver.AddListener(CollectMaterialsFromChildren);
    }

    private void OnDestroy()
    {
        SaveRiver.RemoveListener(CollectMaterialsFromChildren);
    }

    void CollectMaterialsFromChildren()
    {
        foreach (Transform child in transform)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                materials = renderer.materials;
            }

            for (int i = 0; i < materials.Length; i++)
            {
                Material material = materials[i];

                foreach (ColorProperty colorProperty in colorProperties)
                {
                    Color targetColor = colorProperty.color;
                    Color currentColor = material.GetColor(colorProperty.propertyName);
                    StartCoroutine(LerpColor(material, colorProperty.propertyName, targetColor, currentColor));
                }
            }
        }
    }

    IEnumerator LerpColor(Material material, string propertyName, Color targetColor, Color currentColor)
    {
        float transitionDuration = 5f;
        Color initialColor = currentColor;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            Color lerpedColor = Color.Lerp(initialColor, targetColor, elapsedTime / transitionDuration);
            material.SetColor(propertyName, lerpedColor);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        material.SetColor(propertyName, targetColor);
    }
}
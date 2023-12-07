using System;
using UnityEngine;

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

    void Start()
    {
        CollectMaterialsFromChildren();
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
                Shader shader = material.shader;

                foreach (ColorProperty colorProperty in colorProperties)
                {
                    material.SetColor(colorProperty.propertyName, colorProperty.color);
                }

                Debug.Log($"Shader colors changed on {shader.name}");
            }
        }


    }
}



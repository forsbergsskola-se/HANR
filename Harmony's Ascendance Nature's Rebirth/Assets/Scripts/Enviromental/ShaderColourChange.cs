using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]
public class ColorPropertyOne
{
    public string PropertyName;
    public Color Color;
    
    public ColorPropertyOne(string propertyName, Color color)
    {
       Color = color;

       PropertyName = propertyName;
           
    }
}


public class ShaderColourChange : MonoBehaviour
{
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private List<ColorPropertyOne> colorProperties = new List<ColorPropertyOne>();
    [SerializeField] private Transform[] colourTransform;
    [SerializeField] private bool findColorObjects;

    public UnityEvent SaveRiver { get; private set; }

    void Start()
    {
        CollectMaterialsFromChildren();
        if(findColorObjects)
        {
         FindColorProperty();
        }
        SaveRiver.AddListener(ChangeMaterialColour);
    }

    private void OnDestroy()
    {
        SaveRiver.RemoveListener(ChangeMaterialColour);
    }

    void CollectMaterialsFromChildren()
    {
        //materials.Clear(); // Clear the list before collecting materials again
        for (int i = 0; i < colourTransform.Length; i++)
        {
          foreach (Transform child in colourTransform[i])
          {
            Renderer renderer = child.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                Debug.Log("Renderer found on: " + transform.name);
                materials.AddRange(renderer.materials);
            }
            
          }
        }

    
    }

    void ChangeMaterialColour()
    {
        foreach (Material material in materials)
        {
            foreach (ColorPropertyOne colorProperty in colorProperties)
            {
                Color targetColor = colorProperty.Color;
                
                Color currentColor = material.GetColor(colorProperty.PropertyName);
                
                StartCoroutine(LerpColor(material, colorProperty.PropertyName, targetColor, currentColor));
            }
        }
    }

    void FindColorProperty()
    {
        foreach (Material material in materials)
        {
            Shader shader = material.shader;

            int propertyCount = shader.GetPropertyCount();

            for (int i = 0; i < propertyCount; i++)
            {
                string propertyName = shader.GetPropertyName(i);

                // Assuming that properties with names containing "Color" are color properties
                if (propertyName.Contains("Color"))
                {
                    Debug.Log($"Material {material.name} has a color property: {propertyName}");
                    
                    
                    
                    colorProperties.Add(new ColorPropertyOne(propertyName, Color.black));
                    
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

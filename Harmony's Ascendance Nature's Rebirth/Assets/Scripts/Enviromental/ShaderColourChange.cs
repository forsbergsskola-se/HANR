using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]
public class ColorPropertyOne
{
    public string propertyName;
    public Color color;
}

public class ShaderColourChange : MonoBehaviour
{
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private ColorPropertyOne[] colorProperties;
    [SerializeField] private Transform[] colourTransform;

    public UnityEvent SaveRiver;

    void Start()
    {
        CollectMaterialsFromChildren();
        SaveRiver.AddListener(CollectMaterialsFromChildren);
    }

    private void OnDestroy()
    {
        SaveRiver.RemoveListener(CollectMaterialsFromChildren);
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

        foreach (Material material in materials)
        {
            foreach (ColorPropertyOne colorProperty in colorProperties)
            {
                Color targetColor = colorProperty.color;
                Color currentColor = material.GetColor(colorProperty.propertyName);
                StartCoroutine(LerpColor(material, colorProperty.propertyName, targetColor, currentColor));
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

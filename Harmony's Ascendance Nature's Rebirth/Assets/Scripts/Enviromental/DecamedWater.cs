using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecamedWater : MonoBehaviour
{

    [SerializeField] private Material[] materials;

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


                foreach (Material material in materials)
                {

                    Debug.Log("Material found: " + material.name);
                }
            }

            for (int i = 0; i < materials.Length; i++)
            {
                // Access each material here
                Material material = materials[i];

                // Get the shader of the material
                Shader shader = material.shader;
                    
                // Set the color property of the shader
                //TODO Change magic color and magic name
                material.SetColor("_ColorDeep", Color.green);
                material.SetColor("_ColorDepthFade", Color.black);
                material.SetColor("_Color0", Color.green); // Modify as needed
                material.SetColor("_Color1", Color.black); // Modify as needed

                // Print information to the console (replace this with your logic)
                Debug.Log($"Shader color changed on {child.name}: {shader.name}");
            }
        }
    }

}



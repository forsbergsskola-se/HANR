using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHover : MonoBehaviour
{
    public float amplitude = 2f;
    public float speed = 1.5f;
    public float groundLevel = 2.23f; // Set the ground level (Y-coordinate) in the Unity Editor

    private void Update()
    {
        Vector3 p = transform.position;

        // Calculate the Y-coordinate based on the sine wave
        float newY = amplitude * Mathf.Cos(Time.time * speed);

        // Ensure the item hovers above the ground level
        p.y = Mathf.Max(newY, groundLevel);

        // Update the position of the game object to create the hovering effect
        transform.position = p;
    }
}

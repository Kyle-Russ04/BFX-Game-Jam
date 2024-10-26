using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCollarGlow : MonoBehaviour
{
    public CatCollarGlow otherCollar;
    public Vector2 Distance;
    public Color baseColor = Color.white; // Original color of the collar
    public Color brightColor = Color.yellow; // Color when close
    public float maxDistance = 5f;

    void Update()
    {
        Distance = this.transform.position - otherCollar.transform.position;

        // Calculate the magnitude of the distance
        float distanceMagnitude = Distance.magnitude;

        // Normalize the distance to a value between 0 and 1
        float t = Mathf.Clamp01(1 - (distanceMagnitude / maxDistance));

        // Lerp between the base color and the bright color based on distance
        Color currentColor = Color.Lerp(baseColor, brightColor, t);

        // Set the color of the collar
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = currentColor;
        }
    }
}

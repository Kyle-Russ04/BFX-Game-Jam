using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world coordinates
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        // Set the z position to the same as the rectangle's z to avoid depth issues
        mousePosition.z = transform.position.z;

        // Calculate the direction from the rectangle to the mouse position
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle needed to rotate the rectangle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90f));
    }

    void OnDrawGizmos()
    {
        
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world coordinates
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = transform.position.z; // Keep the z position consistent

        // Draw a line from the rectangle to the mouse position
        Gizmos.color = Color.red; // Set the color of the gizmo line
        Gizmos.DrawLine(transform.position, mousePosition);
        /*
        collider2d[] laserhits = Physics2d.overlapline(transform.position, mouseposition, thelevel)
        if (laserhits not empty + not null)
        {
            if laserhits[1] not null
                laserhits.position
                laser stops from that point
                draw line from laser to that point above
        
        }

        */
    }
}

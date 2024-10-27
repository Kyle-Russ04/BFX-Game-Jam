using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    /*void Update()
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
    }*/


    public LineRenderer lineRenderer; // Reference to the LineRenderer component
    public float maxDistance = 100f;  // Maximum distance the laser can reach
    public LayerMask hitLayers;        // Layers that the laser can hit
    public LaserTarget target;
    public bool canBeSeen;

    void Start()
    {
        // Set up the LineRenderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.03f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Use a default shader
        lineRenderer.startColor = Color.red; // Start color of the laser
        lineRenderer.endColor = Color.red;   // End color of the laser
        lineRenderer.useWorldSpace = true;   // Ensure the line is drawn in world space
    }
    public Vector2 targetV2;
    void Update()
    {
        // Get the mouse position in world coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePosition - (Vector2)transform.position, maxDistance, hitLayers);

        Vector3 mousePositionV3 = Input.mousePosition;

        // Convert the mouse position to world coordinates
        mousePositionV3 = Camera.main.ScreenToWorldPoint(mousePositionV3);
        
        // Set the z position to the same as the rectangle's z to avoid depth issues
        mousePositionV3.z = transform.position.z;

        Vector3 direction = mousePositionV3 - transform.position;

        // Calculate the angle needed to rotate the rectangle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90f));

        // Set the LineRenderer's start position
        lineRenderer.SetPosition(0, transform.position); // Start point at the emitter's position
        
        targetV2 = new Vector2(target.transform.position.x, target.transform.position.y);

        float distanceToTarget = Vector2.Distance(transform.position, targetV2);
        float distanceToWall = Vector2.Distance(transform.position, hit.point);



        if (hit.collider != null)
        {
            if(distanceToTarget < distanceToWall)
            {
                lineRenderer.SetPosition(1, target.transform.position);
                canBeSeen = true;
                target.GetComponent<SpriteRenderer>().color = Color.red;
                lineRenderer.endColor = Color.red;
            }else
            {
                // If the laser hits something, set the end position to the hit point
                lineRenderer.SetPosition(1, hit.point); // End point at the hit point
                canBeSeen = false;
                target.GetComponent<SpriteRenderer>().color = Color.white;
                lineRenderer.endColor = Color.white;
            }
        }
        else
        {
            // If nothing is hit, extend the laser to maxDistance
            //lineRenderer.SetPosition(1, (Vector2)transform.position + (mousePosition - (Vector2)transform.position).normalized * maxDistance);
            lineRenderer.SetPosition(1, target.transform.position);
            canBeSeen = true;
            target.GetComponent<SpriteRenderer>().color = Color.red;
            lineRenderer.endColor = Color.red;
        }
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

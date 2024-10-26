using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementByWill : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the character
    private Rigidbody2D rb;
    public bool player2;
    public float moveHorizontal;
    public float moveVertical;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(!player2)
        {
            moveHorizontal = Input.GetAxis("Horizontal_WASD");
            moveVertical = Input.GetAxis("Vertical_WASD");
        }else
        {
            moveHorizontal = Input.GetAxis("Horizontal_Arrows");
            moveVertical = Input.GetAxis("Vertical_Arrows");
        }

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f ) * moveSpeed;
        rb.MovePosition(transform.position + movement * Time.fixedDeltaTime);
    }
}

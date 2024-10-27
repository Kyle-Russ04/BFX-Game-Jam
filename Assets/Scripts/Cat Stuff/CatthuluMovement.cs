using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatthuluMovement : MonoBehaviour
{
    public LaserTarget target;
    public LaserController laser;
    public CatInteraction1 cat2;
    public float PersonalSpace = 0.1f;
    public float Range = 5f;
    public Rigidbody2D rb;
    public Vector2 direction;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2.Distance(target.transform.position, this.transform.position) >= PersonalSpace &
            Vector2.Distance(target.transform.position, transform.position) <= Range) && (laser.canBeSeen))
        {
            FollowLaser();
        }
        else
        {
            //needs to get the position of the cat2 and then follow them
            FollowCat();
            //rb.velocity = new Vector2(0f, 0f);

        }
    }

    void FollowLaser()
    {
        Vector2 direction = ((Vector2)target.transform.position - rb.position).normalized;
        rb.velocity =  direction * speed;
    }
    
    void FollowCat()
    {
        Vector2 catDirection = ((Vector2)cat2.transform.position - rb.position).normalized;
        rb.velocity = catDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HI");
        if (collision.gameObject.CompareTag("Player2") == true)
        {
            Debug.Log("Hit the cat");
            Debug.Log("Loose a life");
            cat2.lives -= 1f;
        }
    }
}

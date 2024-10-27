using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalWinGame : MonoBehaviour
{
    public GameObject cat;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == cat)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLife : MonoBehaviour
{
    public Sprite Life;
    public Sprite deathimage;
    public Image life1;
    public Image life2;
    public Image life3;
    public CatInteraction1 cat;

    public void Start()
    {
        life1.sprite = Life;
        life2.sprite = Life;
        life3.sprite = Life;
    }

    public void Update()
    {
        if (cat.lives > 0)
        {
            UpdateLives();
        }
    }

    public void UpdateLives()
    {
        Debug.Log(cat.lives);
        if (cat.lives == 3)
        {
            life1.sprite = deathimage;
        }
        if (cat.lives == 2)
        {
            life2.sprite = deathimage;
        }
        if (cat.lives == 1)
        {
            life3.sprite = deathimage;
        }
    }


}

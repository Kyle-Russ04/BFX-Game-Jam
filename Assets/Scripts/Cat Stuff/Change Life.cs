using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLife : MonoBehaviour
{
    public Image deathimage;
    public Sprite life;
    public CatInteraction1 cat;


    public void changeImage()
    {
        if (cat.lives > 0)
        {
            updateLives();
        }
    }

    public void updateLives()
    {
        if (cat.lives >= 0)
        {
            deathimage.sprite = life;
        }
    }
}

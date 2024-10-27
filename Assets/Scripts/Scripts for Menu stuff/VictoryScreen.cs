using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public void FinishGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
    }


}

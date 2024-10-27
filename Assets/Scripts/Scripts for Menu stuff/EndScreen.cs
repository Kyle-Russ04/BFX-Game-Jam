using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndScreen : MonoBehaviour
{
    public void FinishGame()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);  
    }

  
}

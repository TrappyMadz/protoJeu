using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainButtons : MonoBehaviour
{
  public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitPressed()
    {
        Application.Quit();
    }
}

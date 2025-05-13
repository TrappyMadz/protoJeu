using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainButtons : MonoBehaviour
{
    [SerializeField] private string MainMenu = "MenuGame";
  public void TryAgain()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void OnApplicationQuit()
    {
        OnApplicationQuit();
    }
}

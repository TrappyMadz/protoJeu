using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private MainManager mainManager;

    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        if (mainManager)
        {
            mainManager.instance.SetPlaying(false);
            mainManager.instance.ResetMainManager();
        }
    }

    public void StartGame()
    {
        if (mainManager)
        {
            mainManager.instance.SetPlaying(true);
            mainManager.instance.StartNextMiniGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

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
            MainManager.instance.SetPlaying(false);
            MainManager.instance.ResetMainManager();
        }
    }

    public void StartGame()
    {
        if (mainManager)
        {
            MainManager.instance.SetPlaying(true);
            MainManager.instance.StartNextMiniGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

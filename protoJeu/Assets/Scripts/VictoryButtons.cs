using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryButtons : MonoBehaviour
{
    [SerializeField] private string MainMenu = "MenuGame";
    public void Replay()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void OnApplicationQuit()
    {
        OnApplicationQuit();
    }
}

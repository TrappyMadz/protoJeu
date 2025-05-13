using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryButtons : MonoBehaviour
{
    [SerializeField] private string MainMenu = "MenuGame";
    [SerializeField] private TMP_Text scoreText;

    private MainManager mainManager;

    private void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        mainManager.instance.SetPlaying(false);

        float timer = mainManager.instance.GetTrueTimer();
        string seconds = Mathf.Round(timer).ToString();
        string milliseconds = (Mathf.Round((timer - Mathf.Floor(timer)) * 1000).ToString());
        

        scoreText.text = $"Temps restant : {seconds}:{milliseconds}";
    }
 
}

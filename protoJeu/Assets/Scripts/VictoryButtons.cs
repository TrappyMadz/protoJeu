using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryButtons : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        MainManager.instance.SetPlaying(false);

        float timer = MainManager.instance.GetTrueTimer();
        string seconds = Mathf.Round(timer).ToString();
        string milliseconds = (Mathf.Round((timer - Mathf.Floor(timer)) * 1000).ToString());
        

        scoreText.text = $"Temps restant : {seconds}:{milliseconds}";
    }
 
}

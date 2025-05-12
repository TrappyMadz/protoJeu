using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntermissionManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timeLeftText;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject lostPanel;
    [SerializeField] private float timeToWaitBetweenMiniGames;

    private MainManager mainManager;


    private void Start()
    {
        mainManager = FindObjectOfType<MainManager>();

        victoryPanel.SetActive(false);
        lostPanel.SetActive(false);

        if (mainManager.instance.GetWasLastGameWon())
        {
            UpdateTimerText(mainManager.instance.GetTrueTimer());
            ShowVictoryPanel();
            StartCoroutine(WaitThenStartNextGame(timeToWaitBetweenMiniGames));
        }
        else
        {
            ShowLostPanel();
        }
    }

    public void UpdateTimerText(float timer)
    {
        timeLeftText.text = timer.ToString();
    }

    public void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true);
    }

    public void ShowLostPanel()
    {
        lostPanel.SetActive(true);
    }
    private IEnumerator WaitThenStartNextGame(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        mainManager.instance.StartNextMiniGame();
    }
}

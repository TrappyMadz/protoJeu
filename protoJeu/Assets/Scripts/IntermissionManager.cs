using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntermissionManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timeLeftText;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject lostPanel;
    [SerializeField] private GameObject firstPanel;
    [SerializeField] private float timeToWaitBetweenMiniGames;

    private MainManager mainManager;


    private void Start()
    {
        mainManager = FindObjectOfType<MainManager>();

        victoryPanel.SetActive(false);
        lostPanel.SetActive(false);
        firstPanel.SetActive(false);

        if (mainManager.instance.GetFirstTime())
        {
            mainManager.instance.SetFirstTime(false);
            StartCoroutine(WaitThenStartFirstGame(timeToWaitBetweenMiniGames));
        }
        else if (mainManager.instance.GetWasLastGameWon())
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
    private IEnumerator WaitThenStartFirstGame(float timeToWait)
    {
        firstPanel.SetActive(true);
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(2);
    }
    private IEnumerator WaitThenStartNextGame(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        mainManager.instance.StartNextMiniGame();
    }
}

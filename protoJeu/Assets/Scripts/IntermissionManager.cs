using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntermissionManager : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject lostPanel;
    [SerializeField] private GameObject firstPanel;
    [SerializeField] private TMP_Text globalTimer;
    [SerializeField] private float timeToWaitBetweenMiniGames;

    private MainManager mainManager;


    private void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        MainManager.instance.SetGlobalTimer(globalTimer);
        victoryPanel.SetActive(false);
        lostPanel.SetActive(false);
        firstPanel.SetActive(false);

        if (MainManager.instance.GetFirstTime())
        {
            MainManager.instance.SetFirstTime(false);
            StartCoroutine(WaitThenStartFirstGame(timeToWaitBetweenMiniGames));
        }
        else if (MainManager.instance.GetWasLastGameWon())
        {
            ShowVictoryPanel();
            StartCoroutine(WaitThenStartNextGame(timeToWaitBetweenMiniGames));
        }
        else
        {
            ShowLostPanel();
        }
        
    }

    public void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true);
    }

    public void ShowLostPanel()
    {
        MainManager.instance.SetPlaying(false);
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
        MainManager.instance.StartNextMiniGame();
    }
}

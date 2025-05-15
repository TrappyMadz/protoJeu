using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGame2 : MonoBehaviour
{

    [SerializeField] TMP_Text globalTimer;
    [SerializeField] TMP_Text timeToFinishText;
    [SerializeField] private float timeToFinish;
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private AudioSource catSound;
    [SerializeField] private AudioSource findGameSound;
    [SerializeField] private GameObject catPanel;
    [SerializeField] private GameObject findGamePanel;

    private float timePassed;
    void Start()
    {
        MainManager.instance.SetGlobalTimer(globalTimer);
        timePassed = 0;
        catPanel.SetActive(false);
        findGamePanel.SetActive(false);
        int rnd = Random.Range(1, 3);

        if (rnd == 1)
        {
            catPanel.SetActive(true);
            catSound.Play();
        }
        else
        {
            findGamePanel.SetActive(true);
            findGameSound.Play();
        }

            StartCoroutine(StartGame());
    }
    public void GoodAns()
    {
        MainManager.instance.MiniGameWon();
    }

    public void BadAns()
    {
        MainManager.instance.MiniGameLost();
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        float timer = timeToFinish - timePassed;
        string seconds = Mathf.Round(timer).ToString();
        string milliseconds = (Mathf.Round((timer - Mathf.Floor(timer)) * 1000).ToString());
        timeToFinishText.text = $"0{seconds}:{milliseconds}";
        if (timePassed > timeToFinish)
        {
            MainManager.instance.MiniGameLost();
        }
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.5f);
        instructionText.gameObject.SetActive(false);
    }
}
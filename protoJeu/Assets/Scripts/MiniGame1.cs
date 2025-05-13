using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGame1 : MonoBehaviour
{
    [SerializeField] private TMP_Text globalTimer;
    [SerializeField] private float timeToFinish;
    [SerializeField] private TMP_Text timeToFinishText;
    [SerializeField] private TMP_Text instructionText;
    private float timePassed;
    private MainManager mainManager;
   void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        mainManager.instance.SetGlobalTimer(globalTimer);
        timePassed = 0;
        StartCoroutine(StartGame());
    }
   public void GoodAns()
    {
        mainManager.instance.MiniGameWon();
    }

    public void BadAns()
    {
        mainManager.instance.MiniGameLost();
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        float timer = timeToFinish - timePassed;
        string seconds = Mathf.Round(timer).ToString();
        string milliseconds = (Mathf.Round((timer - Mathf.Floor(timer)) *1000).ToString());
        timeToFinishText.text = $"0{seconds}:{milliseconds}";
        if (timePassed > timeToFinish)
        {
            mainManager.instance.MiniGameLost();
        }
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.5f);
        instructionText.gameObject.SetActive(false);
    }
}

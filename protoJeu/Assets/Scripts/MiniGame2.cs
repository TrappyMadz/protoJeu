using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGame2 : MonoBehaviour
{

    [SerializeField] TMP_Text globalTimer;
    private MainManager mainManager;
    [SerializeField] TMP_Text timeToFinishText;
    [SerializeField] private float timeToFinish;

    private float timePassed;
    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        mainManager.instance.SetGlobalTimer(globalTimer);
        timePassed = 0;
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
        string milliseconds = (Mathf.Round((timer - Mathf.Floor(timer)) * 1000).ToString());
        timeToFinishText.text = $"0{seconds}:{milliseconds}";
        if (timePassed > timeToFinish)
        {
            mainManager.instance.MiniGameLost();
        }
    }
}
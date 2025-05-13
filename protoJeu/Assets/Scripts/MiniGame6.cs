using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGame6 : MonoBehaviour
{

    private float timer;
    private MainManager mainManager;
    [SerializeField] private TMP_Text globalTimer;
    [SerializeField] TMP_Text timeToFinishText;
    [SerializeField] float timeToFinish;
    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        mainManager.instance.SetGlobalTimer(globalTimer);
        timer = timeToFinish;
    }

    private void Update()
    {
        Timer();
    }

    public void BadAns()
    {
        mainManager.instance.MiniGameLost();
    }

    public void Timer()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            string seconds = Mathf.Round(timer).ToString();
            string milliseconds = (Mathf.Round((timer - Mathf.Floor(timer)) * 1000).ToString());
            timeToFinishText.text = $"0{seconds}:{milliseconds}";
        }
        else if (timer < 0)
        {
            mainManager.MiniGameWon();
        }
    }

}

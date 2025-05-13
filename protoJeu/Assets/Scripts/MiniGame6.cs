using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGame6 : MonoBehaviour
{
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text objectiveText;
    private float timer;
    private bool timerActive;
    private MainManager mainManager;
    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        MiniGameStart();
    }

    private void Update()
    {
        Timer();
    }

    public void BadAns()
    {
        mainManager.instance.MiniGameLost();
    }
    private void MiniGameStart()
    {
        timer = 5;
    }

    public void Timer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {
            mainManager.MiniGameWon();
        }
    }
}

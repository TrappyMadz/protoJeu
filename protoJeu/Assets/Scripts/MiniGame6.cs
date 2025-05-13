using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGame6 : MonoBehaviour
{
    
    private float timer;
    private MainManager mainManager;
    [SerializeField] private TMP_Text globalTimer;
    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        mainManager.instance.SetGlobalTimer(globalTimer);
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

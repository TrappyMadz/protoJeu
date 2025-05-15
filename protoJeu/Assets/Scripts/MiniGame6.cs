using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MiniGame6 : MonoBehaviour
{

    private float timer;
    private MainManager mainManager;
    [SerializeField] private TMP_Text globalTimer;
    [SerializeField] TMP_Text timeToFinishText;
    [SerializeField] float timeToFinish;
    [SerializeField] private GameObject ButtonGreen;
    [SerializeField] private GameObject ButtonRed;
    int choice;


    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        mainManager.instance.SetGlobalTimer(globalTimer);
        timer = timeToFinish;
        ButtonGreen.SetActive(false);
        ButtonRed.SetActive(false);
        choice = Random.Range(1, 3);


        if (choice == 1)
        {
            ButtonRed.SetActive(true);
            //Red();
        }
        else
        {
            ButtonGreen.SetActive(true);
            //Green();
        }
    }

    private void Update()
    {

        Timer();
    }

    public void Red()
    {
        mainManager.MiniGameWon();
        Timer();
        
    }

    public void Green()
    {
     mainManager.instance.MiniGameLost();
        Timer();   
       if (timer < 0)
        {
            mainManager.MiniGameWon();
        }

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
        else
        {
            CheckEnd();
            timeToFinishText.text = "00:000";

        }
       
    }

    private void CheckEnd()
    {
        if (choice == 1 && timer < 0)
        {
            mainManager.MiniGameLost();
        }
        else if (choice == 1)
        {
            mainManager.MiniGameWon();
        }

        if (choice == 2 && timer < 0)
        {
            mainManager.MiniGameWon();
        }
        else if (choice == 2)
        {
            mainManager.MiniGameLost();
        }
    }

}

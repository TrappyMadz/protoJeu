using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MiniGame6 : MonoBehaviour
{

    private float timer;
    [SerializeField] private TMP_Text globalTimer;
    [SerializeField] TMP_Text timeToFinishText;
    [SerializeField] float timeToFinish;
    [SerializeField] private GameObject ButtonGreen;
    [SerializeField] private GameObject ButtonRed;
    int choice;


    void Start()
    {
        MainManager.instance.SetGlobalTimer(globalTimer);
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
        MainManager.instance.MiniGameWon();
        Timer();
        
    }

    public void Green()
    {
     MainManager.instance.MiniGameLost();
        Timer();   
       if (timer < 0)
        {
            MainManager.instance.MiniGameWon();
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
            MainManager.instance.MiniGameLost();
        }
        else if (choice == 1)
        {
            MainManager.instance.MiniGameWon();
        }

        if (choice == 2 && timer < 0)
        {
            MainManager.instance.MiniGameWon();
        }
        else if (choice == 2)
        {
            MainManager.instance.MiniGameLost();
        }
    }

}

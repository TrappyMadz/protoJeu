using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame1 : MonoBehaviour
{
    [SerializeField] private TMP_Text globalTimer;
    [SerializeField] private float timeToFinish;
    [SerializeField] private TMP_Text timeToFinishText;
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private Vector2 pos1;
    [SerializeField] private Vector2 pos2;
    [SerializeField] private Vector2 pos3;
    [SerializeField] private Vector2 pos4;


    private float timePassed;
    private MainManager mainManager;
   void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        MainManager.instance.SetGlobalTimer(globalTimer);
        timePassed = 0;
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
        string milliseconds = (Mathf.Round((timer - Mathf.Floor(timer)) *1000).ToString());
        timeToFinishText.text = $"0{seconds}:{milliseconds}";
        if (timePassed > timeToFinish)
        {
            MainManager.instance.MiniGameLost();
        }
    }

    private IEnumerator StartGame()
    {
        
        ButtonSwitch();
        yield return new WaitForSeconds(0.5f);
        instructionText.gameObject.SetActive(false);

    }

    public void ButtonSwitch()
    {
        Button[] buttonArray = FindObjectsOfType<Button>();
        Shuffle(buttonArray);
        buttonArray[0].GetComponent<RectTransform>().anchoredPosition = pos1;
        buttonArray[1].GetComponent<RectTransform>().anchoredPosition = pos2;
        buttonArray[2].GetComponent<RectTransform>().anchoredPosition = pos3;
        buttonArray[3].GetComponent<RectTransform>().anchoredPosition = pos4;

    }


    public void Shuffle(Button[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int randIndex = Random.Range(0, i + 1);
                (array[i], array[randIndex]) = (array[randIndex], array[i]);
            }
        }


    }

    

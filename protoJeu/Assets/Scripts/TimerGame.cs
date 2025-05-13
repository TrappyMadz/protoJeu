using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerGame : MonoBehaviour
{
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text objectiveText;
    [SerializeField] private TMP_Text globalTimer;
    [SerializeField] private float maxStartValue;
    [SerializeField] private float minStartValue;
    [SerializeField] private Button button;

    private float timer;
    private float objective;
    private bool timerActive;


    private MainManager mainManager;


    // Start is called before the first frame update
    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        mainManager.instance.SetGlobalTimer(globalTimer);
        objectiveText.gameObject.SetActive(false);
        timerText.text = "00:06";
        timerText.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        StartCoroutine(MiniGameStart());
        
    }

    private void Update()
    {
        Timer();
    }

    private IEnumerator MiniGameStart()
    {
        objective = Random.Range(minStartValue, maxStartValue);
        timer = 6;
        objectiveText.text = "00:0" + Mathf.Round(objective).ToString();
        yield return new WaitForSeconds(0.5f);
        objectiveText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        
        timerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        button.gameObject.SetActive(true);

        timerActive = true;
    }

    public void Timer()
    {
        if (timerActive && timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = "00:0" + Mathf.Round(timer).ToString();
        }
        else if (timerActive && timer <= 0)
        {
            mainManager.MiniGameLost();
        }
    }

    public void StopButtonPressed()
    {
        timerActive = false;

        if (Mathf.Round(timer) == Mathf.Round(objective))
        {
            mainManager.MiniGameWon();
        }
        else
        {
            mainManager.MiniGameLost();
        }
    }
}

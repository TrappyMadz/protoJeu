using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    [SerializeField] private float baseTimer;
    [SerializeField] private int miniGamesCount;

    private TMP_Text globalTimer;

    private float trueTimer;
    private bool playing = false;
    private bool wasLastGameWon;
    private bool firstTime;
    private int minigamesMades;
    private bool globalTimerActive;

    public  MainManager instance;

    public bool GetWasLastGameWon()
    {
        return wasLastGameWon;
    }

    public float GetTrueTimer()
    {
        return trueTimer;
    }

    public bool GetFirstTime()
    {
        return firstTime;
    }

    public void SetGlobalTimer(TMP_Text timer)
    {
        globalTimer = timer;
        globalTimerActive = true;
    }

    public void SetPlaying(bool isPlaying)
    {
        playing = isPlaying;
    }

    public void SetFirstTime(bool isFirstTime)
    {
        firstTime = isFirstTime;
    }

    private void Update()
    {
        if (playing && globalTimerActive)
        {
            // Timer
            if (trueTimer > 0)
            {
                trueTimer -= Time.deltaTime;
                globalTimer.text = Mathf.Round(trueTimer).ToString();
            }
            else
            {
                GameEnd();
            }
        }
        
        
    }

    void Awake()
    {
        if (instance == null ||instance == this.gameObject)
        {
            instance = this;
            minigamesMades = 0;
            playing = false;
            firstTime = true;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ResetMainManager()
    {
        trueTimer = baseTimer;
        minigamesMades = 0;
        firstTime = true;
    }

    public void StartNextMiniGame()
    {

        // On load la scène suivante. La scène de victoire suit le dernier mini-jeu
        minigamesMades++;

        if (minigamesMades == 1)
        {
            globalTimerActive = false;
            SceneManager.LoadScene(1);
        }
        else if (minigamesMades <= miniGamesCount + 1)
        {
            globalTimerActive = false;
            SceneManager.LoadScene(minigamesMades + 1);
        }
    }

    public void GameEnd()
    {
        globalTimerActive = false;
        // Dernière scène du projet
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    // Victoire au mini-précédent
    public void MiniGameWon()
    {
        wasLastGameWon = true;
        globalTimerActive = false;
        SceneManager.LoadScene(1);
    }

    public void MiniGameLost()
    {
        wasLastGameWon = false;
        globalTimerActive = false;
        SceneManager.LoadScene(1);
    }


    

}

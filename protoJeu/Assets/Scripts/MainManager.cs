using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    [SerializeField] private float baseTimer;
    [SerializeField] private int miniGamesCount;

    private float trueTimer;
    private bool playing = false;
    private bool wasLastGameWon;
    private bool firstTime;
    private int minigamesMades;

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
        if (playing)
        {
            // Timer
            if (trueTimer > 0)
            {
                trueTimer -= Time.deltaTime;
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
            SceneManager.LoadScene(1);
        }
        else if (minigamesMades <= miniGamesCount + 1)
        {
            SceneManager.LoadScene(minigamesMades + 1);
        }
    }

    public void GameEnd()
    {
        // Dernière scène du projet
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    // Victoire au mini-précédent
    public void MiniGameWon()
    {
        wasLastGameWon = true;
        SceneManager.LoadScene(1);
    }

    public void MiniGameLost()
    {
        wasLastGameWon = false;
        SceneManager.LoadScene(1);
    }


    

}

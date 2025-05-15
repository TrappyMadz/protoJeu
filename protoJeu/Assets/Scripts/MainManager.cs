using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    [SerializeField] private float baseTimer;
    [SerializeField] private int[] miniGames;
    [SerializeField] private int intermissionScene;
    [SerializeField] private int victoryScene;
    [SerializeField] private int miniGamesToPlayCount;

    private TMP_Text globalTimer;
    private int[] toPlay;

    private float trueTimer;
    private bool playing = false;
    private bool wasLastGameWon;
    private bool firstTime;
    private int minigamesMades;
    private bool globalTimerActive;

    public static MainManager instance;

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
        if (firstTime)
        {
            // On mélange la liste de TOUS les minijeux, et on prends les x premiers pour les lancer
            Shuffle(miniGames);
            toPlay = new int[miniGamesToPlayCount];
            for (int i = 0; i < miniGamesToPlayCount; i++)
            {
                toPlay[i] = miniGames[i]; 
            }
            globalTimerActive = false;
            SceneManager.LoadScene(intermissionScene);
        }
        else
        {
            minigamesMades++;
            if (minigamesMades-1 < toPlay.Length)
            {
                globalTimerActive = false;
                SceneManager.LoadScene(toPlay[minigamesMades - 1]);
            }
            else
            {
                globalTimerActive = false;
                SceneManager.LoadScene(victoryScene);
            }
        }


        /** Ancien fonctionement

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
        **/
    }

    public void Shuffle(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randIndex = Random.Range(0, i + 1);
            (array[i], array[randIndex]) = (array[randIndex], array[i]);
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

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }



}

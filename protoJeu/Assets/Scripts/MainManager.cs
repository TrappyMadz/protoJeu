using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    [SerializeField] private float timer;
    [SerializeField] private int miniGamesCount;

    private int minigamesMades;

    private MainManager instance;

    private void Update()
    {
        // Timer
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            GameEnd();
        }
        
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            minigamesMades = 0;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void StartNextMiniGame()
    {
        // On load la scène suivante. La scène de victoire suit le dernier mini-jeu
        minigamesMades++;
        if (minigamesMades <= miniGamesCount + 1)
        {
            SceneManager.LoadScene(minigamesMades + 1);
        }
    }

    public void GameEnd()
    {
        // Dernière scène du projet
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
}

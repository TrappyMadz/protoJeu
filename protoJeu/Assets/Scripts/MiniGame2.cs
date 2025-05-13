using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGame2 : MonoBehaviour
{

    [SerializeField] TMP_Text globalTimer;
    private MainManager mainManager;
    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        mainManager.instance.SetGlobalTimer(globalTimer);
    }
    public void GoodAns()
    {
        mainManager.instance.MiniGameWon();
    }

    public void BadAns()
    {
        mainManager.instance.MiniGameLost();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame2 : MonoBehaviour
{
    private MainManager mainManager;
    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
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
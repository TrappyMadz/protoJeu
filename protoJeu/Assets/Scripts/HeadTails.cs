using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeadTails : MonoBehaviour
{
    [SerializeField] private TMP_Text globalTimer;
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private float timeToFinish;

    private float timePassed;

    private MainManager mainManager;


    // Start is called before the first frame update
    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        mainManager.instance.SetGlobalTimer(globalTimer);
        timePassed = 0;
        StartCoroutine(MiniGameStart());
    }


    private IEnumerator MiniGameStart()
    {
        yield return new WaitForSeconds(0.5f);
        instructionText.gameObject.SetActive(false);
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > timeToFinish)
        {
            mainManager.instance.MiniGameLost();
        }
    }
}

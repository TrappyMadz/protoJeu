using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoBowGame : MonoBehaviour
{
    [SerializeField] private TMP_Text globalTimer;
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private int targetToGet;
    [SerializeField] private float targetsPositionRangeX;
    [SerializeField] private float targetsPositionRangeY;
    [SerializeField] private float timeToFinish;
    [SerializeField] TMP_Text timeToFinishText;

    private float timePassed;
    private Button[] targets;
    private int targetClicked;

    private MainManager mainManager;


    // Start is called before the first frame update
    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        mainManager.instance.SetGlobalTimer(globalTimer);
        timePassed = 0;
        targetClicked = 0;
        targets = FindObjectsOfType<Button>();
        for (int i = 0; i < targets.Length; i++)
        {
            RectTransform rectTransform = targets[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(Random.Range(-targetsPositionRangeX, targetsPositionRangeX), Random.Range(-targetsPositionRangeY, targetsPositionRangeY));
        }
        StartCoroutine(MiniGameStart());
    }


    private IEnumerator MiniGameStart()
    {
        yield return new WaitForSeconds(0.5f);
        instructionText.gameObject.SetActive(false);
    }

    public void TargetClicked(GameObject target)
    {
        Destroy(target);
        targetClicked++;
        if (targetClicked >= targetToGet)
        {
            mainManager.instance.MiniGameWon();
        }
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        float timer = timeToFinish - timePassed;
        string seconds = Mathf.Round(timer).ToString();
        string milliseconds = (Mathf.Round((timer - Mathf.Floor(timer)) * 1000).ToString());
        timeToFinishText.text = $"0{seconds}:{milliseconds}";
        if (timePassed > timeToFinish)
        {
            mainManager.instance.MiniGameLost();
        }
    }
}

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


    private Button[] targets;
    private int targetClicked;

    private MainManager mainManager;


    // Start is called before the first frame update
    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        mainManager.instance.SetGlobalTimer(globalTimer);
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
}

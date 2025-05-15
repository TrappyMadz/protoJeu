using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickMiniGame : MonoBehaviour
{
    [SerializeField] private TMP_Text globalTimer;
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private int nbOfClicksMax;
    [SerializeField] private int nbOfClicksMin;
    [SerializeField] private float timeToFinish;
    [SerializeField] TMP_Text timeToFinishText;
    [SerializeField] GameObject pepperoni;
    [SerializeField] RectTransform rectTransformCanvas;

    private int target;
    private float timePassed;
    private int clicksMades;



    // Start is called before the first frame update
    void Start()
    {
        MainManager.instance.SetGlobalTimer(globalTimer);
        timePassed = 0;
        target = Random.Range(nbOfClicksMin, nbOfClicksMax);
        instructionText.text = $"Put {target} Pepperonis !";
        clicksMades = 0;

        StartCoroutine(MiniGameStart());
    }


    private IEnumerator MiniGameStart()
    {
        yield return new WaitForSeconds(.7f);
        instructionText.gameObject.SetActive(false);
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        float timer = timeToFinish - timePassed;
        string seconds = Mathf.Round(timer).ToString();
        string milliseconds = (Mathf.Round((timer - Mathf.Floor(timer)) * 1000).ToString());
        timeToFinishText.text = $"0{seconds}:{milliseconds}";
        if ((timePassed > timeToFinish) && (clicksMades != target))
        {
            MainManager.instance.MiniGameLost();
        }
        else if (timePassed > timeToFinish)
        {
            MainManager.instance.MiniGameWon();
        }

        if (Input.GetMouseButtonDown(0))
        {
            // On convertis une position en endroit dans le canvas
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransformCanvas, Input.mousePosition, null, out Vector2 spawnPosition);

            GameObject newPepperoni = Instantiate(pepperoni, rectTransformCanvas);
            newPepperoni.GetComponent<RectTransform>().anchoredPosition = spawnPosition;
            clicksMades++;
        }
    }
}

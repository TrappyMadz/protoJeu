using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeadTails : MonoBehaviour
{
    [SerializeField] private TMP_Text globalTimer;
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private Button left;
    [SerializeField] private Button right;
    [SerializeField] private GameObject watchout;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject wall;

    private int playerChoice = 0;

    private MainManager mainManager;


    // Start is called before the first frame update
    void Start()
    {
        wall.GetComponent<Rigidbody2D>().gravityScale = 0;
        watchout.SetActive(false);
        mainManager = FindObjectOfType<MainManager>();
        mainManager.instance.SetGlobalTimer(globalTimer);
        StartCoroutine(MiniGameStart());
    }


    private IEnumerator MiniGameStart()
    {
        yield return new WaitForSeconds(0.5f);
        instructionText.gameObject.SetActive(false);
        int rnd = Random.Range(1, 3);

        if (rnd == 1)
        {
            TeleportAnim(left.GetComponent<RectTransform>().anchoredPosition, watchout);
        }
        else
        {
            TeleportAnim(right.GetComponent<RectTransform>().anchoredPosition, watchout);
        }
        
        watchout.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        watchout.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        watchout.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        watchout.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        watchout.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        watchout.SetActive(true);

        GameEnd(rnd);

        yield return new WaitForSeconds(.7f);

        if (player.transform.position.y < -350)
        {
            mainManager.instance.MiniGameLost();
        }
        else
        {
            mainManager.instance.MiniGameWon();
        }
    }

    public void TeleportAnim(Vector2 position, GameObject watchout)
    {
        watchout.GetComponent<RectTransform>().anchoredPosition = position;
        watchout.SetActive(true);
    }

    public void playerClicked(int choice)
    {
        playerChoice = choice;
        if (choice == 1)
        {
            TeleportAnim(left.GetComponent<RectTransform>().anchoredPosition, player);
        }
        else
        {
            TeleportAnim(right.GetComponent<RectTransform>().anchoredPosition, player);
        }
    }

    public void GameEnd(int notSafePlace)
    {
        if (notSafePlace == 1)
        {
            TeleportAnim(new Vector2(-460, 590), wall);
            wall.GetComponent<Rigidbody2D>().gravityScale = 1000;
        }
        else
        {
            TeleportAnim(new Vector2(460, 590), wall);
            wall.GetComponent<Rigidbody2D>().gravityScale = 1000;
        }
    }
}

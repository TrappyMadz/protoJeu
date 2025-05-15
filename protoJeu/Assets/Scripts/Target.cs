using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Target : MonoBehaviour, IPointerClickHandler
{
    private int hp;

    [SerializeField] private Sprite target3;
    [SerializeField] private Sprite target2;
    [SerializeField] private Sprite target1;
    [SerializeField] private Image selfImage;
    [SerializeField] private CowboyScene script;

    private void Start()
    {
        hp = 3;
        selfImage.sprite = target3;
    }

    public void OnPointerClick(PointerEventData pointer)
    {
        hp--;
        if (hp <= 0)
        {
            Destroy(gameObject);
            script.TargetClickedPlus();
        }
        else if (hp == 1)
        {
            selfImage.sprite = target1;
        }
        else if (hp == 2)
        {
            selfImage.sprite = target2;
        }
        

    }
}

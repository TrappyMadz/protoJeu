using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerGlobal : MonoBehaviour
{
    private MainManager mainManager;
   
    // Start is called before the first frame update
    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

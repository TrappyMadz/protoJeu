using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartoucheMovement : MonoBehaviour
{
    public float vitesse = 2f;           
    public float yMin = 440f;

    void Start()
    {

    }
    void Update()
    {
        
        if (transform.position.y > yMin)
        {
            
            float nouvelleY = transform.position.y - vitesse * Time.deltaTime;
            nouvelleY = Mathf.Max(nouvelleY, yMin);

            transform.position = new Vector3(transform.position.x, nouvelleY, transform.position.z);

        }

        
    }
}

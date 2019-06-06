using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroFromStars : MonoBehaviour
{
 
    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter2D(Collision2D col)
    {
  
        CarScript.IncreaseSpeed();
       
        // on collision enter with star car gets nitro


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{

    public static float moveSpeed = 1f;         // x,y axis movement speed multiplier

    private Vector3 vectorSpeed;                    // movement speed vector

    public static float nitroTimer = 3f;        //time on speed boost

    public GameObject nitroLayer;                    
   
    public float speedMultiplier = 10f;             // Y axis movement multiplier
    // Start is called before the first frame update
    void Start()
    {
        
        vectorSpeed = new Vector3(0f, speedMultiplier, 0f);
        
    
    }

    // Update is called once per frame
    void Update()
    {
        nitroTimer -= Time.deltaTime;
        if (nitroTimer <= 0) {
            moveSpeed = 1f;                             //3 seconds till nitro off
            nitroLayer.SetActive(false);
        }

                               
       
        gameObject.transform.Translate(0f, 1.5f * Input.GetAxis("Vertical")  * moveSpeed * Time.deltaTime, 0f, Space.World);                  //vertical move speed on W,S 
        if ((gameObject.transform.position.x <= 1.8) && gameObject.transform.position.x >= -1.8) { 
            gameObject.transform.Translate(4f * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f, Space.World);                 //horizontal move speed on A,D
            gameObject.transform.position += (vectorSpeed * Time.deltaTime * 0.85f * moveSpeed);                                             //default movement speed
        }

        else {
            gameObject.transform.Translate(0.5f * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f, Space.World);       // slow the player outside the road

            gameObject.transform.position += (vectorSpeed * Time.deltaTime * 0.40f * moveSpeed);
        }
        
      

    }
    public static void IncreaseSpeed()
    {
               
                moveSpeed = 1.85f;                       // speed multiplier after picking nitro
                nitroTimer = 3f;
                 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "CollectibleStar") {
            nitroLayer.SetActive(true);
          Destroy(col.gameObject);
        
        }
        //destroy the star


    }

}  // to do : slowing player after leaving the road

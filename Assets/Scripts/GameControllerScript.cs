using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public GameObject star, barrel;
    private float a = -1.2f;
    private float b = 1.2f;
    private float timer = 10f;
    public GameObject Player;
    public static GameObject PlayerTag;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {

            int roadSide = Random.Range(-2, 3);
            float barrelRespawnLenght1 = Random.Range(10, 15);
            float barrelRespawnLenght2 = Random.Range(10, 15);
            if (Player != null)
            {
                /////////left side of road
                if (roadSide < 0)
                {

                    Vector3 spawnVectorStar = new Vector3(a, Player.transform.position.y + 10f, 0f);      //left side of road to spawn  star
                    Vector3 spawnVectorBarrel1 = new Vector3(a, Player.transform.position.y + 15f, 0f);      //left side of road to spawn  barrel1
                    Vector3 spawnVectorBarrel2 = new Vector3(a, Player.transform.position.y + 20f, 0f);    //left side of road to spawn  barrel2

                    Debug.Log(spawnVectorBarrel1);
                    Debug.Log(spawnVectorBarrel2);

                    Instantiate(star, spawnVectorStar, Quaternion.identity);
                    Instantiate(barrel, spawnVectorBarrel1, Quaternion.identity);
                    if (((barrelRespawnLenght1 - barrelRespawnLenght2) > 1) || (barrelRespawnLenght2 - barrelRespawnLenght1) < 1)
                    {           //check if 2 vectors arent on same y position to avoid instant collisions
                        Instantiate(barrel, spawnVectorBarrel2, Quaternion.identity);
                    }
                    timer = Random.Range(10, 20);
                }
                ////////right side of road
                else
                {
                    Vector3 spawnVectorStar = new Vector3(b, Player.transform.position.y + 10f, 0f);     // right side of road to spawn star
                    Vector3 spawnVectorBarrel1 = new Vector3(b, Player.transform.position.y + 15f, 0f);      //left side of road to spawn  barrel1
                    Vector3 spawnVectorBarrel2 = new Vector3(b, Player.transform.position.y + 20f, 0f);    //left side of road to spawn  barrel2

                    Debug.Log("PRAWA");
                    Debug.Log(spawnVectorBarrel1);
                    Debug.Log(spawnVectorBarrel2);

                    Instantiate(star, spawnVectorStar, Quaternion.identity);
                    Instantiate(barrel, spawnVectorBarrel1, Quaternion.identity);
                    if (((barrelRespawnLenght1 - barrelRespawnLenght2) > 1) || (barrelRespawnLenght2 - barrelRespawnLenght1) < 1)
                    {                  //check if 2 vectors arent on same y position to avoid instant collisions
                        Instantiate(barrel, spawnVectorBarrel2, Quaternion.identity);
                    }

                    timer = Random.Range(10, 20);
                }
            }
        }
    }
    public static void DestroyBarrell(BarrelScript barrel) {                    //using gamecontroller to destroy object of barrel or car outside their own scripts
        Debug.Log(barrel.transform.position);
        if (barrel.gameObject.tag == "Barrel") {
            PlayerTag = GameObject.FindGameObjectWithTag("Player");
            Debug.Log(PlayerTag.transform.position);
            Destroy(PlayerTag);
            Destroy(barrel.gameObject);
        }
    }
}

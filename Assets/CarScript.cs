using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    Transform transform;
    private Vector3 randomPos;
    // Start is called before the first frame update
    void Start()
    {
        float randomR = 10f;
        randomPos = new Vector3(0f, randomR, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += (randomPos * Time.deltaTime * 0.2f);
       
        gameObject.transform.Translate(0f, 4f * Input.GetAxis("Vertical") * Time.deltaTime, 0f, Space.World);

        gameObject.transform.Translate(4f * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f, Space.World);

    }
}  // to do : slowing player after leaving the road

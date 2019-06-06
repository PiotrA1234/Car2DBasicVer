using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class TilingGrassDirt : MonoBehaviour
{

    public int offsetX = 2;         // offset to make smooth addition of new tiles (predict upcoming end of tile)
    public GameObject Player;

    private bool hasATopSprite = false;
    private float spriteHeight = 25.5f;
    float size = 0f;


    private Camera cam;
    private Transform myTransform;

    void Awake()
    {
        cam = Camera.main;
        myTransform = transform;

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

        // checking if we have already a sprite
        if (hasATopSprite == false)
        {
            // size of camera
            float camHorizontalExtend = cam.orthographicSize;

            // calculate the y position where the camera can see the edge of the sprite (element)
            float edgeVisiblePositionTop = (myTransform.position.y + spriteHeight - 8*offsetX) - camHorizontalExtend;



            // checking if we can see the edge of the element and then creating new sprite
            if (cam.transform.position.y >= edgeVisiblePositionTop - offsetX && hasATopSprite == false)
            {
                MakeNewSprite();

                hasATopSprite = true;
            }

        }
        if(Player!=null)
        if ((Player.transform.position.y - myTransform.position.y) > 20)
        {
            Destroy(gameObject, 15);     //respawning after time
        }

    }
    public void MakeNewSprite()
    {

        // calculating the new position for new buddy
        // Debug.Log(myTransform.position.y);
        Vector3 newPosition = new Vector3(myTransform.position.x, myTransform.position.y + spriteHeight, myTransform.position.z);

        Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

        //parenting to not make mess in hierarchy windows
        newBuddy.parent = myTransform.parent;
       



    }
}





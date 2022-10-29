using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private float cameraOffset = -10;
    //NEED TO WORK OUT A WAY TO SET BUFFERS BY DETECTION OF MAP SIZE ---- DONE!
    private Collider2D camCollide;
    private Vector2 cameraLimit;
    private float cameraBufferX;
    private float cameraBufferY;
    public bool boundsReached;



    void Start()
    {
        camCollide = GameObject.Find("GroundCollision").GetComponent<Collider2D>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        cameraLimit = camCollide.bounds.extents;
        cameraBufferX = camCollide.bounds.extents.x / 2;
        cameraBufferY = camCollide.bounds.extents.y / 2;
    }


    void Update()
    {
        //Lock Camera to Player
        transform.position = new Vector3(playerControllerScript.transform.position.x, playerControllerScript.transform.position.y, cameraOffset);
        //Test camera bounds
        if  (transform.position.x - cameraBufferX < -cameraLimit.x)
        {
            transform.position = new Vector3(-cameraLimit.x + cameraBufferX, transform.position.y, cameraOffset);
            boundsReached = true;                
        }
        if (transform.position.x + cameraBufferX > cameraLimit.x)
        {
            transform.position = new Vector3(cameraLimit.x - cameraBufferX, transform.position.y, cameraOffset);
            boundsReached = true; 
        }
        if (transform.position.y - cameraBufferY < -cameraLimit.y)
        {
            transform.position = new Vector3(transform.position.x, -cameraLimit.y + cameraBufferY, cameraOffset);
            boundsReached = true; 
        }
        if (transform.position.y + cameraBufferY > cameraLimit.y)
        {
            transform.position = new Vector3(transform.position.x, cameraLimit.y - cameraBufferY, cameraOffset);
            boundsReached = true;
        } else
        {
            boundsReached = false;
        }

    }
            
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    public Vector2 mousePos;
    [SerializeField] private Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos;
    }
}

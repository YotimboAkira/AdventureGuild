using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    private GameObject inventory;
    private GameObject playerCenter;
    public float walkSpeed;
    public float runSpeed;
    private Vector2 moveInput;
    public Vector2 boxSize = new Vector2(.1f, .1f);


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inventory = GameObject.Find("Inventory");
        playerCenter = GameObject.Find("PlayerCenter");

        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        moveInput = new Vector2(horizontalInput, verticalInput);
        walkSpeed = 1f;

        //Open Inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!inventory.activeInHierarchy)
            {
                inventory.SetActive(true);
            }
            else
            {
                inventory.SetActive(false);
            }
        }
        //Interact with Objects
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
        //Attack is Handled in the Aiming script




            
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            walkSpeed *= 1.5f;
        }
        rb.MovePosition(rb.position += moveInput * walkSpeed * Time.fixedDeltaTime);

    }

    private void TryInteract()
    {
        RaycastHit2D[] hits = (Physics2D.BoxCastAll(playerCenter.transform.position, boxSize, 0, Vector2.zero));
            {
            if (hits.Length > 0)
            {
                foreach (RaycastHit2D rc in hits)
                {
                    if (rc.transform.GetComponent<InteractableObject>())
                    {
                        rc.transform.GetComponent<InteractableObject>().Interact();
                        return;
                    }
                }
            }
        }
    }
}








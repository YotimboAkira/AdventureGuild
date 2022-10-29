using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : InteractableObject
{
    public Item item;

    public override void Interact()
    {
        //Inventory inventory;

        //inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();


        //for (int i = 0; i < inventory.slots.Length; i++)
        //{
        //if (inventory.isFull[i] == false)
        //{
        //inventory.isFull[i] = true;
        //Instantiate(item.icon, inventory.slots[i].transform, false);
        //}
        bool wasPickedUp = Inventory.instance.Add(item);
        Debug.Log(item.name + " picked up");
        

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }

    }    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VicinityCheck : MonoBehaviour
{
    private ItemPickUp itemPickUp;
    private Item item;
    
    private void Start()
    {
        //Gets Objects from itemScript and scriptable object
        itemPickUp = GetComponent<ItemPickUp>();
        item = GetComponent<Item>();

    }

    private void OnCollisionStay(Collision other)
    {
        //For input and if it is player is called on collision stay sin
        if (Input.GetKeyDown(KeyCode.G) && other.gameObject.CompareTag("Player"))
        {
            itemPickUp.PickUp(item);
        }
    }
}

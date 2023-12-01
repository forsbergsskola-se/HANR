using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private InventoryHolder inventoryHolder;
    public Item item;
    private bool Inside;
    
    private void Start()
    {
        inventoryHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryHolder>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && Inside)
        {
            
            //Adds item Pickup
            PickUp();
            
            Debug.Log("Pickup");

        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          
            Debug.Log("true");
            Inside = true;
          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Inside = false;
        }
    }
    
    public void PickUp()
    {
        inventoryHolder.Items.Add(item);
        inventoryHolder.pickUp.Invoke();
        Destroy(gameObject);
        Debug.Log("event invoked");
    }

}

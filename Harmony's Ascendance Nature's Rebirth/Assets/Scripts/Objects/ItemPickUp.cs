using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEditor;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private InventoryHolder inventoryHolder;
    public Item item;
    public Item defaultItem;
    private bool Inside;

    [SerializeField] private Instructions instructions;
    
    private void Start()
    {
        inventoryHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryHolder>();
        instructions = FindObjectOfType<Instructions>().GetComponent<Instructions>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && Inside)
        {
            //Adds item Pickup
            PickUp();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            instructions.gameObject.SetActive(true);
            instructions.buttonInput.Invoke("Item");
            Inside = true;
          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {          
            instructions.gameObject.SetActive(false);
            Inside = false;
        }
    }
    
    public void PickUp()
    {
        for(int i = 0; i < 5; i++)
        {
            if(inventoryHolder.Items[i] == defaultItem)
            {
                inventoryHolder.Items[i] = item;
                break;
            }
        }
        SFX.SoundManager.PlaySound("Item Pick Up");
        instructions.gameObject.SetActive(false);
        inventoryHolder.pickUp.Invoke();
        Destroy(gameObject);
        
    }

}

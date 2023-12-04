using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UsableItems : MonoBehaviour
{
    private InventoryHolder inventoryHolder;
    
    public UnityEvent startStaffEquipped;
    public UnityEvent fireStaffEquipped;
    public UnityEvent waterStaffEquipped;

    [SerializeField] private Item defaultItem;
 
    
    
    void Start()
    {
        
        inventoryHolder = GetComponent<InventoryHolder>();
        
    }
    
    
    
    void Update()
    {
        
        CheckInput();
        
    }

    void CheckInput()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventoryHolder.Items[0] != defaultItem)
        {
            Debug.Log("Key 1 pressed");
            CheckSlot(0);
         
        }
        
        else if (Input.GetKeyDown(KeyCode.Alpha2) && inventoryHolder.Items[1] != defaultItem)
        {
            Debug.Log("Key 2 pressed");
            CheckSlot(1);
           
        }
        
        else if (Input.GetKeyDown(KeyCode.Alpha3) && inventoryHolder.Items[2] != defaultItem)
        {
            Debug.Log("Key 3 pressed");
            CheckSlot(2);
            
        }
        
        else if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryHolder.Items[3] != defaultItem)
        {
            Debug.Log("Key 4 pressed");
            CheckSlot(3);
            
        }
        
        else if (Input.GetKeyDown(KeyCode.Alpha5) && inventoryHolder.Items[4] != defaultItem)
        {
            Debug.Log("Key 5 pressed");
            CheckSlot(4);
            
        }
    }
    
    

    void CheckSlot(int slotIndex)
    {
        Item itemInSlot = inventoryHolder.Items[slotIndex];
        if (itemInSlot != defaultItem)
        {
            if (itemInSlot.itemClass == "Weapon")
            {

                if (itemInSlot.itemID == "Starter Staff")
                {
                    startStaffEquipped.Invoke();
                }
                if (itemInSlot.itemID == "Fire Staff")
                {
                    Debug.Log("Fire Weapon");
                    fireStaffEquipped.Invoke();
                }
                if (itemInSlot.itemID == "Water Staff")
                {
                    Debug.Log("Water Weapon");
                    waterStaffEquipped.Invoke();
                }
                
            }

            if (itemInSlot.itemClass == "Consumable")
            {
                itemInSlot.consumable.Invoke();
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public InventoryHolder inventoryHolder;
    
    public void PickUp(Item item)
    {
        inventoryHolder.Items.Add(item);
        inventoryHolder.pickUp.Invoke();
    }
}

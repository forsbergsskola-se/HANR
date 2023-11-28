using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
public class InventoryUI : MonoBehaviour
{
    public Image imageComponent;
    
    public void Update()
    { 
        //I made the inventoryholder a list instead of an array 
        this.imageComponent.sprite = FindObjectOfType<InventoryHolder>().Items[0].itemIcon;
    }
}

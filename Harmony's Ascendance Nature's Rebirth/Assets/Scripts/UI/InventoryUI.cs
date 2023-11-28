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
        this.imageComponent.sprite = FindObjectOfType<InventoryHolder>().inventory[0].itemIcon;
    }
}

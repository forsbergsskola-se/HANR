using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InventoryHolder : MonoBehaviour
{
    public static InventoryHolder instance;
    
    public UnityEvent pickUp;
    
    public List<Item> Items = new List<Item>();
    
    
    void Start()
    {
        instance = this;
    }
    
}
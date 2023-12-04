using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class InventoryUI : MonoBehaviour
{
    public List<Image> slots = new List<Image>(){};
    public Item defaultImage;
    public GameObject player;
    private InventoryHolder inventoryHolder;

    public void Awake()
    {
        inventoryHolder = player.GetComponent<InventoryHolder>();
        SetUpHUD();
        inventoryHolder.pickUp.AddListener(UpdateInventoryHUD);
    }

    public void OnDestroy()
    {
        inventoryHolder.pickUp.RemoveListener(UpdateInventoryHUD);
    }

    void SetUpHUD()
    {
        for (int i = 0; i < 5; i++)
        {
            inventoryHolder.Items.Add(defaultImage);
            slots[i].sprite = defaultImage.itemIcon;
            Color color = slots[i].color;
            color.a = 0f;
            slots[i].color = color;
        }
    }

    void UpdateInventoryHUD()
    {
        for (int i = 0; i < 5; i++)
        {
            if (inventoryHolder.Items[i] != defaultImage && slots[i].sprite == defaultImage.itemIcon)
            {
               
                switch (i)
                {
                    
                    case 0:
                        Debug.Log("0");
                        slots[i].sprite = inventoryHolder.Items[i].itemIcon;
                        Color color = slots[i].color;
                        color.a = 1f;
                        slots[i].color = color;
                        break;
                    case 1:
                        slots[i].sprite = inventoryHolder.Items[i].itemIcon;
                        color = slots[i].color;
                        color.a = 1f;
                        slots[i].color = color;
                        break;
                    case 2:
                        slots[i].sprite = inventoryHolder.Items[i].itemIcon;
                        color = slots[i].color;
                        color.a = 1f;
                        slots[i].color = color;
                        break;
                    case 3:
                        slots[i].sprite = inventoryHolder.Items[i].itemIcon;
                        color = slots[i].color;
                        color.a = 1f;
                        slots[i].color = color;
                        break;
                    case 4:
                        slots[i].sprite = inventoryHolder.Items[i].itemIcon;
                        color = slots[i].color;
                        color.a = 1f;
                        slots[i].color = color;
                        break;
                }

                // Update additional UI elements here if needed
            }
        }

    }
}


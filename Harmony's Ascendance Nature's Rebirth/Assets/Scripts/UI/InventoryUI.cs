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

    public List<Image> slots = new List<Image>();
    public Sprite defaultImage;
    public GameObject player;
    private InventoryHolder inventoryHolder;

    public void Awake()
    {
        SetUpHUD();
        inventoryHolder = player.GetComponent<InventoryHolder>();
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
            slots[i].sprite = defaultImage;
        }
    }

    void UpdateInventoryHUD()
    {
        Debug.Log("we called");
        for (int i = 0; i < 5; i++)
        {
            if (inventoryHolder.Items[i] != null && slots[i].sprite == defaultImage)
            {
                switch (i)
                {
                    case 0:
                        Debug.Log("0");
                        slots[i].sprite = inventoryHolder.Items[i].itemIcon;
                        break;
                    case 1:
                        slots[i].sprite = inventoryHolder.Items[i].itemIcon;
                        break;
                    case 2:
                        slots[i].sprite = inventoryHolder.Items[i].itemIcon;
                        break;
                    case 3:
                        slots[i].sprite = inventoryHolder.Items[i].itemIcon;
                        break;
                    case 4:
                        slots[i].sprite = inventoryHolder.Items[i].itemIcon;
                        break;
                }

                // Update additional UI elements here if needed
            }
        }

    }
}


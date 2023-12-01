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
    public Image slotOne;
    public Image slotTwo;
    public Image slotThree;
    public Image slotFour;
    public Image slotFive;
    public GameObject player;
    
    public void Awake()
    {
        SetUpHUD();
        player.GetComponent<InventoryHolder>().pickUp.AddListener(UpdateInventoryHUD);
    }

    public void OnDestroy()
    {
        player.GetComponent<InventoryHolder>().pickUp.RemoveListener(UpdateInventoryHUD);
    }

    void SetUpHUD()
    {
        if (FindObjectOfType<InventoryHolder>().Items[0])
        {
            this.slotOne.sprite = FindObjectOfType<InventoryHolder>().Items[0].itemIcon;
            this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite =
                slotOne.sprite;
        }

        if (FindObjectOfType<InventoryHolder>().Items[1])
        {
            this.slotTwo.sprite = FindObjectOfType<InventoryHolder>().Items[1].itemIcon;
            this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite =
                slotTwo.sprite;
        }

        if (FindObjectOfType<InventoryHolder>().Items[2])
        {
            this.slotThree.sprite = FindObjectOfType<InventoryHolder>().Items[2].itemIcon;
            this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite =
                slotThree.sprite;
        }

        if (FindObjectOfType<InventoryHolder>().Items[3])
        {
            this.slotFour.sprite = FindObjectOfType<InventoryHolder>().Items[3].itemIcon;
            this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite =
                slotFour.sprite;
        }

        if (FindObjectOfType<InventoryHolder>().Items[4])
        {
            this.slotFive.sprite = FindObjectOfType<InventoryHolder>().Items[4].itemIcon;
            this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite =
                slotFive.sprite;
        }
    }
    
    void UpdateInventoryHUD()
    {
            this.slotOne.sprite = FindObjectOfType<InventoryHolder>().Items[0].itemIcon;
            this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite =
                slotOne.sprite;
        

            this.slotTwo.sprite = FindObjectOfType<InventoryHolder>().Items[1].itemIcon;
            this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite =
                slotTwo.sprite;
        

            this.slotThree.sprite = FindObjectOfType<InventoryHolder>().Items[2].itemIcon;
            this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite =
                slotThree.sprite;
        

            this.slotFour.sprite = FindObjectOfType<InventoryHolder>().Items[3].itemIcon;
            this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite =
                slotFour.sprite;
        
            this.slotFive.sprite = FindObjectOfType<InventoryHolder>().Items[4].itemIcon;
            this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite =
                slotFive.sprite;
    }
}

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
        player.GetComponent<InventoryHolder>().pickUp.AddListener(UpdateInventoryHUD);
    }

    public void OnDestroy()
    {
        player.GetComponent<InventoryHolder>().pickUp.RemoveListener(UpdateInventoryHUD);
    }

    void UpdateInventoryHUD()
    {
        this.slotOne.sprite = FindObjectOfType<InventoryHolder>().Items[0].itemIcon;
        this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite = slotOne.sprite;
            
        this.slotTwo.sprite = FindObjectOfType<InventoryHolder>().Items[1].itemIcon;
        this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite = slotTwo.sprite;
            
        this.slotThree.sprite = FindObjectOfType<InventoryHolder>().Items[2].itemIcon;
        this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite = slotThree.sprite;
            
        this.slotFour.sprite = FindObjectOfType<InventoryHolder>().Items[3].itemIcon; 
        this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite = slotFour.sprite; 
            
        this.slotFive.sprite = FindObjectOfType<InventoryHolder>().Items[4].itemIcon;
        this.gameObject.GetComponentInChildren<ItemSlotSprite>().gameObject.GetComponent<Image>().sprite = slotFive.sprite;
    }
}
